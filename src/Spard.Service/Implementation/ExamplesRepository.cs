﻿using Spard.Service.Contract;
using Spard.Service.Helpers;
using Spard.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Spard.Service.Implementation
{
    /// <inheritdoc />
    internal sealed class ExamplesRepository : IExamplesRepository
    {
        private readonly Dictionary<int, ExampleModel> _examples = new Dictionary<int, ExampleModel>();

        public void AddExample(int exampleId, ExampleModel exampleModel)
        {
            _examples[exampleId] = exampleModel;
        }

        public SpardExampleInfo GetExample(int id, string culture = CultureHelper.DefaultCulture) =>
            !_examples.TryGetValue(id, out var exampleModel)
                ? null
                : new SpardExampleInfo
                {
                    Id = id,
                    Name = GetLocalizedString(exampleModel.Name, culture),
                    Input = exampleModel.Input,
                    Transform = exampleModel.Transform
                };

        public IEnumerable<SpardExampleBaseInfo> GetExamples(string culture = CultureHelper.DefaultCulture) =>
            _examples.Select(exampleEntry => new SpardExampleBaseInfo
            {
                Id = exampleEntry.Key,
                Name = GetLocalizedString(exampleEntry.Value.Name, culture)
            });

        private static string GetLocalizedString(Dictionary<string, string> localizedDictionary, string culture) =>
            localizedDictionary.TryGetValue(culture, out var localizedName) ? localizedName : null;
    }
}
