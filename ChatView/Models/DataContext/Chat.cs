using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatView.Models.DataContext
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Seen { get; set; }
        public bool? CallOrChat { get; set; }
        [ForeignKey("McustomerFromId")]
        public virtual Mcustomer FromId { get; set; }
        [ForeignKey("McustomerToId")]
        public virtual Mcustomer ToId { get; set; }
        [MaxLength(250)]
        public string FilePath { get; set; }
    }
}
