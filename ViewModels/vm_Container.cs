using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace MVC5T_CallOver.ViewModels
{
    public class vm_Container {

        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Name = "Container No")]
        public string ContainerNo { get; set; }

        public string Type { get; set; }

        [Display(Name = "Voyage No")]
        public string VoyageNo { get; set; }

        public string Port { get; set; }

        [Display(Name = "Haulier A/C")]
        public string HaulierAC { get; set; }

        [Display(Name = "Haulier Name")]
        public string HaulierName { get; set; }

        [Display(Name = "Dest/Origin")]
        public string DestinationOrigin { get; set; }

        [Display(Name = "Booking Date")]
        public DateTime? BookingDate
        {
            get
            {
	    	return dbBookingDate ?? null;
            }
        }

        public DateTime? BookingTime
        {
            get
            {
                if (dbBookingDate.HasValue && dbBookingTime.HasValue)
                {
                    return new DateTime(1, 1, 1, dbBookingTime.Value.Hours, dbBookingTime.Value.Minutes, dbBookingTime.Value.Seconds);
                }
                if (dbBookingDate.HasValue && !dbBookingTime.HasValue)
                {
                    return new DateTime(1, 1, 1, dbBookingTime.Value.Hours, dbBookingTime.Value.Minutes, dbBookingTime.Value.Seconds);
                }
                if (!dbBookingDate.HasValue && dbBookingTime.HasValue)
                {
                    return new DateTime(1, 1, 1, dbBookingTime.Value.Hours, dbBookingTime.Value.Minutes, dbBookingTime.Value.Seconds);
                }

                return null;
            }
        }

        [Display(Name = "Gate Date")]
        public DateTime? GateDate
        {
            get
            {
                return dbGateDate ?? null;
            }
        }

        public DateTime? GateTime
        {
            get
            {
                if (dbGateDate.HasValue && dbGateTime.HasValue)
                {
                    return new DateTime(1, 1, 1, dbGateTime.Value.Hours, dbGateTime.Value.Minutes, dbGateTime.Value.Seconds);
                }
                if (dbGateDate.HasValue && !dbGateTime.HasValue)
                {
                    return new DateTime(1, 1, 1, dbGateTime.Value.Hours, dbGateTime.Value.Minutes, dbGateTime.Value.Seconds);
                }
                if (!dbGateDate.HasValue && dbGateTime.HasValue)
                {
                    return new DateTime(1, 1, 1, dbGateTime.Value.Hours, dbGateTime.Value.Minutes, dbGateTime.Value.Seconds);
                }

                return null;
            }
        }

        [ScaffoldColumn(false)]
        public DateTime? dbBookingDate { get; set; }

        [ScaffoldColumn(false)]
        public TimeSpan? dbBookingTime { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? dbGateDate { get; set; }

        [ScaffoldColumn(false)]
        public TimeSpan? dbGateTime { get; set; }

        [ScaffoldColumn(false)]
        public string DateCheck
        {
            get
            {
                if (GateDate.HasValue && BookingDate.HasValue)
                {
                    if (GateDate.Value.Date > BookingDate.Value.Date)
                        return "OFF DATE";
                    else
                        return "ON DATE";
                }
                else
                {
                    return "CHECK";
                }
            }
        }

        [ScaffoldColumn(false)]
        public string Band1
        {
            get
            {
                if(GateDate.HasValue && BookingDate.HasValue)
                {
                    var tempGateDate = GateDate.Value;
                    var check = tempGateDate.AddHours(3);

                    if ((check.Date) < BookingDate.Value.Date && check.TimeOfDay < BookingDate.Value.TimeOfDay)
                    {
                        return "ON TIME";
                    }
                    else
                    {
                        return "CHECK 1";
                    }
                }
                else
                {
                    return "CHECK 1";
                }
            }
        }

        [ScaffoldColumn(false)]
        public string Band2
        {
            get
            {
                if (GateDate.HasValue && BookingDate.HasValue)
                {
                    var tempGateDate = GateDate.Value;
                    var check = tempGateDate.AddHours(2);

                    if (check.Date < BookingDate.Value.Date && check.TimeOfDay < BookingDate.Value.TimeOfDay)
                    {
                        return "ON TIME";
                    }
                    else
                    {
                        return "CHECK 2";
                    }
                }
                else
                {
                    return "CHECK 2";
                }
            }
        }

        [ScaffoldColumn(false)]
        public string Band3
        {
            get
            {
                if (GateDate.HasValue && BookingDate.HasValue)
                {
                    var tempGateDate = GateDate.Value;
                    var check = tempGateDate.AddHours(1);

                    if (check.Date < BookingDate.Value.Date && check.TimeOfDay < BookingDate.Value.TimeOfDay)
                    {
                        return "ON TIME";
                    }
                    else
                    {
                        return "CHECK 3";
                    }
                }
                else
                {
                    return "CHECK 3";
                }
            }
        }

        [ScaffoldColumn(false)]
        public string Band4
        {
            get
            {
                if (GateDate.HasValue && BookingDate.HasValue)
                {
                    if (GateDate.Value < BookingDate.Value)
                    {
                        return "ON TIME";
                    }
                    else
                    {
                        return "LATE";
                    }
                }
                else
                {
                    return "CHECK 4";
                }
            }
        }
    }
}
