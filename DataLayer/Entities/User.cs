using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User
    {
        public User()
        {
            
        }



        [Key]
        public int UserId { get; set; }




        [Display(Name = "نام مخاطب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }




        [Display(Name = "نام خانوادگی مخاطب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Family { get; set; }





        [Display(Name = "سن مخاطب")]
        public int? Age { get; set; }



        
        [Phone]
        [Display(Name = "شماره تماس مخاطب")] 
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} شماره موبایل اشتباه وارد شده .")]
        [MinLength(11, ErrorMessage = "شماره موبایل کم وارد شده")]
        public string Mobile { get; set; }





        [Display(Name = "ادرس مخاطب")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Address { get; set; }
    }
}
