using EnduranceJudge.Core.Models;
using EnduranceJudge.Gateways.Desktop.Services;
using System;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class FormBase : ViewModelBase, IIdentifiable
    {
        protected FormBase()
        {
        }

        protected FormBase(INavigationService navigation)
        {
            this.Navigation = navigation;
        }

        protected INavigationService Navigation { get; }

        private int id;
        public int Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }


        // protected void AddDependant<T>(List<)


        protected Action NavigateToDependantCreateDelegate<T>(Action<object> action)
            where T : IView
        {
            return () => this.Navigation.ChangeTo<T>(action);
        }

        protected Action NavigateToDependantUpdateDelegate<TView>(object data, Action<object> action)
            where TView : IView
        {
            return () => this.Navigation.ChangeTo<TView>(data, action);
        }

        public bool Equals(IIdentifiable identifiable)
        {
            if (this.Id != default &&  identifiable.Id != default)
            {
                return this.Id == identifiable.Id;
            }

            return false;
        }

        public override bool Equals(object other)
        {
            if (this.Equals(other as IIdentifiable))
            {
                return true;
            }

            return base.Equals(other);
        }

        public override bool Equals(IObject other)
        {
            if (this.Equals(other as IIdentifiable))
            {
                return true;
            }

            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.Id;
        }
    }
}
