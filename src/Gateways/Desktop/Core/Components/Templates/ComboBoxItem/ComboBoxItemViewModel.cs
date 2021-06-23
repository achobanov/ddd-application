﻿using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Core.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ComboBoxItem
{
    public class ComboBoxItemViewModel : IMapFrom<ListItemModel>
    {
        public ComboBoxItemViewModel()
        {
        }

        public ComboBoxItemViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; private set;  }

        public string Name { get; private set; }

        public static IEnumerable<ComboBoxItemViewModel> FromEnum<T>()
            where T : struct, Enum
        {
            var names = Enum.GetNames<T>();
            var values = Enum
                .GetValues<T>()
                .Cast<int>()
                .ToArray();

            for (var i = 0; i < names.Length; i++)
            {
                var name = names[i];
                var value = values[i];

                yield return new ComboBoxItemViewModel(value, name);
            }
        }
    }
}