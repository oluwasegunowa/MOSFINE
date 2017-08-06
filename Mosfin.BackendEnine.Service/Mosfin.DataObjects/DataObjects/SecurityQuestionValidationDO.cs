using System;
namespace Mosfin.DataObjects.DataObjects
{
    public class SecurityQuestionValidationDO:BaseDO
    {
        

        public long SecurityQuestionId { get; set; }
        public string Email { get; set; }
        public string Answer { get; set; }
    }
}
