﻿using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Reactive.Subjects;
using System.Reflection;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{
    abstract class AbstractMemoryData
    {
        public abstract void ReadDataFromEmulator(AbstractEmulatorWrapper emulatorWrapper);
    }

    abstract class AbstractMemoryDataObserver
    {
        public abstract void BindAllEvent(ReplaySubject<Tuple<ItemLogicPopertyName, object>> replaySubject);

        public void CompareAndUpdateAllField(AbstractMemoryData previousMemoryData, AbstractMemoryData newMemoryData)
        {
            foreach (var field in newMemoryData.GetType().GetFields())
                CompareAndUpdateField(previousMemoryData, newMemoryData, field.Name);
        }

        private void CompareAndUpdateField(AbstractMemoryData previousMemoryData, AbstractMemoryData newMemoryData, String fieldName)
        {
            if (IsFieldNeedToBeUpdated(previousMemoryData, newMemoryData, fieldName))
                InvokeDataObserverEvent(this, fieldName, GetMemoryDataProp(newMemoryData, fieldName));
        }

        private bool IsFieldNeedToBeUpdated(AbstractMemoryData previousMemoryData, AbstractMemoryData newMemoryData, String fieldName)
        {
            var newMemoryDataProp = GetMemoryDataProp(newMemoryData, fieldName);
            if (newMemoryDataProp != null && newMemoryData.Equals(GetMemoryDataProp(previousMemoryData, fieldName)))
                return false;
            return true;
        }

        private object GetMemoryDataProp(AbstractMemoryData abstractMemoryData, String fieldName)
        {
            return abstractMemoryData.GetType().GetField(fieldName).GetValue(abstractMemoryData);
        }

        private void InvokeDataObserverEvent(AbstractMemoryDataObserver abstractMemoryDataObserver, String fieldName, object newMemoryDataProp)
        {
            var dataObserverEvent = abstractMemoryDataObserver.GetType().GetField(fieldName).GetValue(abstractMemoryDataObserver);
            dataObserverEvent.GetType().InvokeMember(
                    "OnNext",
                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                    null,
                    dataObserverEvent,
                    new object[] { newMemoryDataProp });
        }
    }
}
