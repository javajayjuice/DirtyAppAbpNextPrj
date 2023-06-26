using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistActivity
    {
        [Description("Grade 12 learner")]
        Grade12Learner,

        [Description("International School learner")]
        InternationalSchoolLearner,

        [Description("Technical college student")]
        TechnicalCollegeStudent,

        [Description("Labour force (work)")]
        LabourForce,

        [Description("Technikon student")]
        TechnikonStudent,

        [Description("Nursing college student")]
        NursingCollegeStudent,

        [Description("Unemployed")]
        Unemployed,

        [Description("Teachers’ college student")]
        TeachersCollegeStudent,

        [Description("University student")]
        UniversityStudent,

        [Description("Other")]
        Other
    }
}
