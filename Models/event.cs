//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webpro_quiz2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public partial class @event
    {
        public int event_id { get; set; }
        
        [DisplayName("Event Organizer")]
        public int event_organizer { get; set; }

        [Required]
        [DisplayName("Event name")]
        [StringLength(50)]
        public string event_name { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(1, 1000000000)]
        [DataType(DataType.Currency)]
        public decimal event_price { get; set; }

        [Required]
        [DisplayName("Location")]
        [StringLength(50)]
        public string event_place { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime event_start_date { get; set; }

        [Required]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        public System.TimeSpan event_start_time { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime event_end_date { get; set; }

        [Required]
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        public System.TimeSpan event_end_time { get; set; }
    
        public virtual user user { get; set; }
    }
}
