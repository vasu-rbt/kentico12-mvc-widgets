using System;
using System.Collections.Generic;
namespace Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Models
{
    public class MessageBoardViewModel
    {        
        public string UserComments { get; set; }        
        public string PageUrl { get; set; }
        public string CustomtableName { get; set; }
        public string SubmitButtonText { get; set; }
        public string UserFirstName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ItemCreatedWhen { get; set; }
        public List<MessageBoardViewModel> CustomTableData { get; set; }
    }
}
