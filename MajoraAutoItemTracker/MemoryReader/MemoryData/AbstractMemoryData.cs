using System;
using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{
    abstract class AbstractMemoryData<ItemLogicPropertyName>
    {
        public abstract void ReadDataFromEmulator(AbstractRomController emulatorWrapper);

        public abstract Dictionary<ItemLogicPropertyName, object> GetMemoryDataMap();

        public List<Tuple<ItemLogicPropertyName, object>> CompareWithPreviousAndReturnDiff(AbstractMemoryData<ItemLogicPropertyName>? previousMemoryData)
        {
            var currentMemoryData = GetMemoryDataMap();
            List<Tuple<ItemLogicPropertyName, object>> listOfUpdatedPropertyName = new List<Tuple<ItemLogicPropertyName, object>>();
            foreach (var propertyBool in currentMemoryData)
                if (previousMemoryData == null || !previousMemoryData.GetMemoryDataMap()[propertyBool.Key].Equals(propertyBool.Value))
                    listOfUpdatedPropertyName.Add(new Tuple<ItemLogicPropertyName, object>(propertyBool.Key, propertyBool.Value));
            return listOfUpdatedPropertyName;
        }
    }
}
