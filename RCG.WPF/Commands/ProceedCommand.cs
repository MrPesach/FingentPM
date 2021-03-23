using RCG.CoreApp.Interfaces.Product;
using RCG.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCG.WPF.Commands
{
    public class ProceedCommand : AsyncCommandBase
    {
        public ProceedCommand(
            ImportPriceListViewModel importPriceListViewModel,
            IProductService productService)
        {

        }
        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
