namespace AutofacProject.Models
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageQueryParams
    { 
        /// <summary>
      /// 当前页码
      /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页数据量
        /// </summary>
        public int Limit { get; set; }
    }
}
