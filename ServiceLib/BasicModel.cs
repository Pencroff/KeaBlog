using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLib.Interfaces;

namespace ServiceLib
{
    public class BasicModel : IPagedModel, ISeoModel
    {
        #region Implementation of IPagedModel

        public int Page { get; set; }
        public int StartPageIndex { get; set; }
        public int EndPageIndex { get; set; }

        #endregion

        #region Implementation of ISeoModel

        public string TitleSeo { get; set; }
        public string KeywordsSeo { get; set; }
        public string DescriptionSeo { get; set; }

        #endregion
    }
}
