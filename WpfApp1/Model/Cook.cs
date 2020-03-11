using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OrderMakingApp
{
    public class Cook : IComparable
    {
        [JsonPropertyAttribute]
        public Qualification Qualification_ { get; private set; }

        [JsonPropertyAttribute]
        public Specialization Specialization_ { get; private set; }

        [JsonPropertyAttribute]
        public DateTime EndOfWorkTime { get; private set; } = DateTime.Now;

        [JsonPropertyAttribute]
        public List<Dish> Queue { get; private set; } = new List<Dish>();
        public Cook(Qualification qualification, Specialization spec)
        {
            Qualification_ = qualification;
            Specialization_ = spec;
           // EndOfWorkTime = DateTime.Now;
        }

        private bool CanCookDish(Dish dish)
        {
            if (dish.Cuisine == this.Specialization_)
                return true;
            else
                return false;
        }

        public DateTime CookDish(Dish dish)
        {
            if (CanCookDish(dish))
            {
                double QualificationBonus = (int)((Qualification)Enum.Parse(typeof(Qualification), Qualification_.ToString())) / (double)100;
                TimeSpan CookingTimeWithBonus = dish.CookingTime - TimeSpan.FromTicks((long)(dish.CookingTime.Ticks * QualificationBonus));

                if (EndOfWorkTime < DateTime.Now)
                    EndOfWorkTime = DateTime.Now + CookingTimeWithBonus;
                else
                    EndOfWorkTime += CookingTimeWithBonus;
                dish.CookedAt = EndOfWorkTime;
                Queue.Add(dish);
                return EndOfWorkTime;
            }
            else
                throw new Exception("Cook doesn't have specialization for this dish");

        }

        int IComparable.CompareTo(object obj)
        {
            Cook that = obj as Cook;
            if (this.EndOfWorkTime.Date != that.EndOfWorkTime.Date)
                return this.EndOfWorkTime.Date.CompareTo(that.EndOfWorkTime.Date); // this буде перед that в списку
            else
            {
                if (this.EndOfWorkTime.Hour != that.EndOfWorkTime.Hour)
                    return this.EndOfWorkTime.Hour.CompareTo(that.EndOfWorkTime.Hour);
                else
                {
                    if (this.EndOfWorkTime.Minute != that.EndOfWorkTime.Minute)
                        return this.EndOfWorkTime.Minute.CompareTo(that.EndOfWorkTime.Minute);
                    else
                    {
                        if (this.EndOfWorkTime.Second != that.EndOfWorkTime.Second)
                            return this.EndOfWorkTime.Second.CompareTo(that.EndOfWorkTime.Second);
                        else
                        {
                            int this_bonus = (int)((Qualification)Enum.Parse(typeof(Qualification), this.Qualification_.ToString()));
                            int that_bonus = (int)((Qualification)Enum.Parse(typeof(Qualification), that.Qualification_.ToString()));
                            if (this_bonus > that_bonus)
                                return -1;
                            else
                                return 1;
                        }
                    }
                }
            }
        }
    }
}
