namespace UnopenedEscape.Audio
{
    public enum AudioChannel
    {
        Music,
        Ambience,
        Sfx
    }

    /// <summary>
    /// Identificadores de todos os sons do jogo, alinhados a Tabela 2 do SGDD (docs/sgdd/assets.md).
    /// </summary>
    public enum SfxId
    {
        // Trilha Sonora
        MusicaHorrorPsicologico,
        MusicaEncerramentoVitoria,
        MusicaEncerramentoDerrota,

        // SFX Ambiente
        RadioChiado,
        Goteiras,
        FaiscasEletricas,
        PassosNoTeto,
        SotaoVento,
        RatosCorrendo,
        AmpulhetaAreia,

        // SFX Interacao
        EngrenagensCubo,
        FeedbackRotacao,
        SnapMagnetico,
        CliqueAutenticacao,
        SliderFriccao,

        // SFX Evento
        RadioDesligando,
        AlarmeIntruso,
        ComportasFechando,
        CadeiraArrastada,
        Escotilha,
        MesaBalancando,
        TetoEspinhos,
        Blackout,

        // SFX Punicao / Feedback
        AreiaAcelerada,
        EngrenagensVitoria,
        EstruturasDerrota,

        // SFX Terror
        EntidadeSussurros,

        // Puzzle "Sons Metalicos"
        TapCurto,
        TapLongo
    }
}
