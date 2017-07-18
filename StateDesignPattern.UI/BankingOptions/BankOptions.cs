using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateDesignPattern.UI.BankingOptions {
    public class BankOptions : IEnumerable<IBankOption> {
        private readonly IEnumerable<IBankOption> _options;

        public BankOptions(IEnumerable<IBankOption> options) {
            _options = options;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<IBankOption> GetEnumerator() {
            return _options.GetEnumerator();
        }

        public string Display() {
            var display = new StringBuilder();
            foreach (var option in _options)
                display.AppendLine($"\t{option.Display}");
            return display.ToString();
        }

        public IBankOption Find(string key) {
            var option = _options.FirstOrDefault(o => o.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase));
            return option ?? new UnknownOption();
        }
    }
}