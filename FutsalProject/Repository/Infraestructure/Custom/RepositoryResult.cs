using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Infraestructure.Custom
{
    public class RepositoryResult
    {
        public bool ActionResult { get; set; }
        public Exception Error { get; set; }

        public RepositoryResult(bool result)
        {
            ActionResult = result;
        }
    }
}
