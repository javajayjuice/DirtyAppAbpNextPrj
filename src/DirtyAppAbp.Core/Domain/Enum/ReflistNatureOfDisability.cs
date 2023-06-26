using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistNatureOfDisability
    {
        [Description("Normal")]
        Normal,

        [Description("Cerebral Palsy")]
        CerebralPalsy,

        [Description("Blind")]
        Blind,

        [Description("Reading disorder/Dyslexia")]
        ReadingDisorder,

        [Description("Deaf")]
        Deaf,

        [Description("Paraplegic")]
        Paraplegic,

        [Description("Low vision")]
        LowVision,

        [Description("ADHD")]
        ADHD,

        [Description("Impaired Hearing")]
        ImpairedHearing,

        [Description("Quadriplegic")]
        Quadriplegic,

        [Description("Dyscalculia")]
        Dyscalculia,

        [Description("Impaired mobility")]
        ImpairedMobility,

        [Description("Writing disorder")]
        WritingDisorder,

        [Description("Speech impairment")]
        SpeechImpairment
    }
}
