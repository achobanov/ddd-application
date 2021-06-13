using EnduranceJudge.Gateways.Desktop.Core.Commands;
using Prism.Commands;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class FormBase : ViewModelBase
    {
        protected FormBase()
        {
            this.Submit = new AsyncCommand(this.SubmitAction);
        }

        private int id;
        public int Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }

        public DelegateCommand Submit { get; }
        protected abstract Task SubmitAction();
    }
}
