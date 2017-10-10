using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nim.Models
{
    public class Piece : INotifyPropertyChanged
    { 
        //This is a boolean for if the piece was removed
        private bool isremoved;

        public bool IsRemoved
        {
            get { return isremoved; }
            set
            {
                isremoved = value;
                FieldChanged();
            }
        }


        //This is to notify if the property of IsRemoved changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
