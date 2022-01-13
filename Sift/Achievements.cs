using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sift
{
    class Achievements
    {

        private bool blncompleteted, blnnovice, blnpro, blnmaster, blnsortcomplete, blnincorrectnumbers, blnnumberscompleted, blnalternate, blnarrivingfromid, blnfailedsearch, blnbeatensearch, blnarrivingfromsearch;

        public bool blnCompleteted
        {
            get
            {
                return blncompleteted;
            }

            set
            {
                blncompleteted = value;
            }
        }

        public bool blnNovice
        {
            get
            {
                return blnnovice;
            }

            set
            {
                blnnovice = value;
            }
        }

        public bool blnPro
        {
            get
            {
                return blnpro;
            }

            set
            {
                blnpro = value;
            }
        }

        public bool blnMaster
        {
            get
            {
                return blnmaster;
            }

            set
            {
                blnmaster = value;
            }
        }

        public bool blnSortComplete
        {
            get
            {
                return blnsortcomplete;
            }

            set
            {
                blnsortcomplete = value;
            }
        }

        public bool blnIncorrectNumbers
        {
            get
            {
                return blnincorrectnumbers;
            }

            set
            {
                blnincorrectnumbers = value;
            }
        }

        public bool blnNumbersCompleted
        {
            get
            {
                return blnnumberscompleted;
            }

            set
            {
                blnnumberscompleted = value;
            }
        }
        public bool blnAlternate
        {
            get
            {
                return blnalternate;
            }

            set
            {
                blnalternate = value;
            }
        }   

            public bool blnArrivingFromId
        {
            get
            {
                return blnarrivingfromid;
            }

            set
            {
                blnarrivingfromid = value;
            }
        }

        public bool blnFailedSearch
        {
            get
            {
                return blnfailedsearch;
            }

            set
            {
                blnfailedsearch = value;
            }
        }

        public bool blnBeatenSearch
        {
            get
            {
                return blnbeatensearch;
            }

            set
            {
                blnbeatensearch = value;
            }
        }

        public bool blnArrivingFromSearch
        {
            get
            {
                return blnarrivingfromsearch;
            }

            set
            {
                blnarrivingfromsearch = value;
            }
        }

    }
}