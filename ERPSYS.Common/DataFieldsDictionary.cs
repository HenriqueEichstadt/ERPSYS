namespace ERPSYS.Common
{
    public class DataFieldsDictionary
    {
        /*public new object this[string key]
        {
            get
            {
                object obj;
                if (!this.TryGetValue(key, out obj))
                    this.ThrowKeyNotFoundException(key);
                ILazyLoadedValue lazyLoadedValue = obj as ILazyLoadedValue;
                if (lazyLoadedValue != null)
                    return lazyLoadedValue.RetrieveValue();
                return obj;
            }
            set
            {
                bool flag = this.ContainsKey(key);
                this.SetFieldChangedEvent(key, value);
                if (this.ItemValueChanging != null)
                    this.ItemValueChanging((object) this, new ItemValueChangeEventArgs(key));
                if (!this.ValidateContainsKeyOnSet | flag)
                {
                    base[key] = value;
                    if (!flag || this.ItemValueChanged == null)
                        return;
                    this.ItemValueChanged((object) this, new ItemValueChangeEventArgs(key));
                }
                else
                    this.ThrowKeyNotFoundException(key);
            }
        }*/
    }
}