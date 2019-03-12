using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyiBatisWeb.Models.MetaTable
{
    public class StudentViewModel
    {
        [Key]
        [DisplayName("學號")]
        public int StudId { get; set; }
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("生日")]
        public DateTime Birthday { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }

    }
}