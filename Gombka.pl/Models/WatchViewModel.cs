using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gombka.pl.Models.Entities;

namespace Gombka.pl.Models
{
    public class WatchViewModel
    {
        public VideoEntity Video { get; set; }
        public VoteEntity? VoteEntity { get; set; }
        public int PositiveVotesPercentage
        {
            get
            {
                if (Video.Votes == null)
                {
                    return 0;
                }

                return Convert.ToInt32(PositiveVotesCount / Video.Votes.Count * 100);
            }
        }
        public VoteTypes? TypeOfVoteMajority
        {
            get
            {
                if (Video.Votes == null)
                {
                    return null;
                }

                return PositiveVotesCount >= NegativeVotesCount ? VoteTypes.Positive : VoteTypes.Negative;
            }
        }
        public int PositiveVotesCount
        {
            get
            {
                if (Video.Votes == null)
                {
                    return 0;
                }

                return Video.Votes.Where(vote => vote.Type == VoteTypes.Positive).Count();
            }
        }
        public int NegativeVotesCount
        {
            get
            {
                if (Video.Votes == null)
                {
                    return 0;
                }

                return Video.Votes.Count - PositiveVotesCount;
            }
        }
    }
}
