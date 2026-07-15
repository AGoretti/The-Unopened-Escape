#!/usr/bin/env python3
"""
Baixa os efeitos sonoros/musicas listados em tools/sound_manifest.json.

Fonte primaria: Freesound.org (precisa de FREESOUND_API_KEY no ambiente).
Fallback sem autenticacao: Kenney.nl "Impact Sounds" (CC0), usado apenas
para os taps do puzzle "Sons Metalicos" caso o Freesound nao retorne nada.

Uso:
    FREESOUND_API_KEY=xxxx python3 tools/download_sounds.py

Idempotente: arquivos ja existentes em Assets/Audio/Resources/Audio/ sao pulados.
Gera Assets/Audio/CREDITS_AUDIO.txt com autor/licenca/URL de cada som baixado.
"""
import json
import os
import re
import sys
import time
import urllib.request
import urllib.parse
import zipfile
import tempfile

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
AUDIO_DIR = os.path.join(ROOT, "Assets", "Audio", "Resources", "Audio")
MANIFEST_PATH = os.path.join(ROOT, "tools", "sound_manifest.json")
CREDITS_PATH = os.path.join(ROOT, "Assets", "Audio", "CREDITS_AUDIO.txt")

FREESOUND_API_KEY = os.environ.get("FREESOUND_API_KEY", "").strip()
FREESOUND_SEARCH_URL = "https://freesound.org/apiv2/search/text/"
FREESOUND_SOUND_URL = "https://freesound.org/apiv2/sounds/{id}/"
FIELDS = "id,name,previews,license,username,url"

KENNEY_IMPACT_PAGE = "https://kenney.nl/assets/impact-sounds"
# Nomes de arquivo dentro do pack usados como fallback para os taps do puzzle.
KENNEY_TAP_CURTO_CANDIDATES = ["impactMetal_000.ogg", "impactMetal_001.ogg"]
KENNEY_TAP_LONGO_CANDIDATES = ["impactMetal_002.ogg", "impactMetal_003.ogg"]


def http_get_json(url):
    req = urllib.request.Request(url, headers={"User-Agent": "TheUnopenedEscape-AudioDownloader/1.0"})
    with urllib.request.urlopen(req, timeout=30) as resp:
        return json.loads(resp.read().decode("utf-8"))


def http_download(url, dest_path):
    req = urllib.request.Request(url, headers={"User-Agent": "TheUnopenedEscape-AudioDownloader/1.0"})
    with urllib.request.urlopen(req, timeout=60) as resp:
        data = resp.read()
    os.makedirs(os.path.dirname(dest_path), exist_ok=True)
    with open(dest_path, "wb") as f:
        f.write(data)


def freesound_lookup(entry):
    """Retorna dict com previews/license/username/name/url, ou None se nada encontrado."""
    if "freesound_id" in entry:
        url = FREESOUND_SOUND_URL.format(id=entry["freesound_id"])
        url += "?fields=" + FIELDS + "&token=" + FREESOUND_API_KEY
        try:
            return http_get_json(url)
        except Exception as e:
            print(f"  [warn] freesound_id {entry['freesound_id']} falhou: {e}")
            return None

    query = entry["query"]
    extra_filter = entry.get("filter", "")

    for license_filter in ['license:"Creative Commons 0"', ""]:
        filt = " ".join(f for f in [license_filter, extra_filter] if f)
        params = {
            "query": query,
            "sort": "downloads_desc",
            "fields": FIELDS,
            "page_size": 1,
            "token": FREESOUND_API_KEY,
        }
        if filt:
            params["filter"] = filt
        url = FREESOUND_SEARCH_URL + "?" + urllib.parse.urlencode(params)
        try:
            result = http_get_json(url)
        except Exception as e:
            print(f"  [warn] busca '{query}' falhou: {e}")
            return None
        results = result.get("results", [])
        if results:
            return results[0]
    return None


def ensure_kenney_taps(missing_files):
    """Baixa e extrai o pack Kenney Impact Sounds so se algum tap estiver faltando."""
    needed = [f for f in missing_files if f.endswith("puzzle_tap_curto.ogg") or f.endswith("puzzle_tap_longo.ogg")]
    if not needed:
        return {}

    print("Buscando pack Kenney Impact Sounds (fallback para taps do puzzle)...")
    try:
        req = urllib.request.Request(KENNEY_IMPACT_PAGE, headers={"User-Agent": "Mozilla/5.0"})
        with urllib.request.urlopen(req, timeout=30) as resp:
            html = resp.read().decode("utf-8", errors="ignore")
    except Exception as e:
        print(f"  [warn] nao consegui acessar a pagina Kenney: {e}")
        return {}

    match = re.search(r'https://[^"\']+impact-sounds[^"\']*\.zip', html)
    if not match:
        print("  [warn] nao encontrei link .zip na pagina Kenney")
        return {}
    zip_url = match.group(0)

    tmp_dir = tempfile.mkdtemp(prefix="kenney_impact_")
    zip_path = os.path.join(tmp_dir, "impact.zip")
    try:
        http_download(zip_url, zip_path)
        with zipfile.ZipFile(zip_path) as zf:
            zf.extractall(tmp_dir)
    except Exception as e:
        print(f"  [warn] download/extracao do pack Kenney falhou: {e}")
        return {}

    all_files = []
    for dirpath, _, filenames in os.walk(tmp_dir):
        for fn in filenames:
            if fn.lower().endswith((".ogg", ".wav")):
                all_files.append(os.path.join(dirpath, fn))
    all_files.sort()

    # Preferir arquivos com "metal" no nome (taps do puzzle sao metalicos); cair
    # para qualquer arquivo do pack se nao houver nenhum.
    metal_files = [f for f in all_files if "metal" in os.path.basename(f).lower()]
    pool = metal_files if len(metal_files) >= 2 else all_files

    result = {}
    if len(pool) >= 2:
        if any(f.endswith("puzzle_tap_curto.ogg") for f in needed):
            result["Puzzle/puzzle_tap_curto.ogg"] = ("kenney", pool[0])
        if any(f.endswith("puzzle_tap_longo.ogg") for f in needed):
            result["Puzzle/puzzle_tap_longo.ogg"] = ("kenney", pool[min(1, len(pool) - 1)])
    return result


def main():
    if not FREESOUND_API_KEY:
        print("AVISO: FREESOUND_API_KEY nao definida no ambiente.")
        print("Crie uma key gratuita em https://freesound.org/apiv2/apply/ e rode:")
        print("  FREESOUND_API_KEY=xxxx python3 tools/download_sounds.py")
        print("Tentando apenas o fallback Kenney (sem autenticacao) para os taps do puzzle...\n")

    with open(MANIFEST_PATH, "r", encoding="utf-8") as f:
        manifest = json.load(f)

    entries = manifest["sounds"]
    credits_lines = []
    failures = []
    missing_files = []

    for entry in entries:
        rel_path = entry["file"]
        dest_path = os.path.join(AUDIO_DIR, rel_path)

        if os.path.exists(dest_path):
            print(f"[skip] {rel_path} ja existe")
            continue

        if not FREESOUND_API_KEY:
            missing_files.append(rel_path)
            continue

        print(f"[busca] {rel_path} ...")
        result = freesound_lookup(entry)
        time.sleep(1)  # rate limit

        if not result:
            print(f"  [falha] nenhum resultado para {rel_path}")
            failures.append(rel_path)
            missing_files.append(rel_path)
            continue

        previews = result.get("previews", {})
        preview_url = previews.get("preview-hq-ogg") or previews.get("preview-hq-mp3")
        if not preview_url:
            print(f"  [falha] sem preview disponivel para {rel_path}")
            failures.append(rel_path)
            missing_files.append(rel_path)
            continue

        try:
            http_download(preview_url, dest_path)
            print(f"  [ok] {rel_path}  <-  {result.get('name')} by {result.get('username')}")
            credits_lines.append(
                f"{rel_path}\n"
                f"  Nome: {result.get('name')}\n"
                f"  Autor: {result.get('username')}\n"
                f"  Licenca: {result.get('license')}\n"
                f"  URL: {result.get('url')}\n"
            )
        except Exception as e:
            print(f"  [falha] download de {rel_path} falhou: {e}")
            failures.append(rel_path)
            missing_files.append(rel_path)

    # Fallback Kenney para os taps do puzzle, se necessario
    kenney_results = ensure_kenney_taps(missing_files)
    for rel_path, (source, local_path) in kenney_results.items():
        dest_path = os.path.join(AUDIO_DIR, rel_path)
        os.makedirs(os.path.dirname(dest_path), exist_ok=True)
        with open(local_path, "rb") as src, open(dest_path, "wb") as dst:
            dst.write(src.read())
        print(f"  [ok-kenney] {rel_path}  <-  {os.path.basename(local_path)}")
        credits_lines.append(f"{rel_path}\n  Fonte: Kenney.nl Impact Sounds (CC0)\n  URL: {KENNEY_IMPACT_PAGE}\n")
        if rel_path in failures:
            failures.remove(rel_path)
        if rel_path in missing_files:
            missing_files.remove(rel_path)

    if credits_lines:
        os.makedirs(os.path.dirname(CREDITS_PATH), exist_ok=True)
        mode = "a" if os.path.exists(CREDITS_PATH) else "w"
        with open(CREDITS_PATH, mode, encoding="utf-8") as f:
            if mode == "w":
                f.write("Creditos dos assets de audio (gerado por tools/download_sounds.py)\n")
                f.write("=" * 70 + "\n\n")
            f.writelines(line + "\n" for line in credits_lines)

    remaining = [e["file"] for e in entries if not os.path.exists(os.path.join(AUDIO_DIR, e["file"]))]
    print()
    print(f"Concluido: {len(entries) - len(remaining)}/{len(entries)} arquivos presentes.")
    if remaining:
        print("Faltando (rode novamente apos ajustar manifest/API key):")
        for r in remaining:
            print(f"  - {r}")
        sys.exit(1)


if __name__ == "__main__":
    main()
