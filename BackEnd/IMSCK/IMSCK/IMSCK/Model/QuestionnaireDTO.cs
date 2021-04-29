using IMSCK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.Model
{
    public class QuestionnaireDto
    {
        public Dictionary<string, string> symptoms { get; set; }

        public string username { get; set; }

    }

}
