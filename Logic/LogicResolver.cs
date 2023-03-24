using MajoraAutoItemTracker.Model.Check;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using System.Collections.Generic;
using System.Diagnostics;

namespace MajoraAutoItemTracker.Model
{
    class LogicResolver
    {
        private Dictionary<string, Logic.Logic> _logicDictionary = new Dictionary<string, Logic.Logic>();
        private Dictionary<string, CheckLogic> _checkLogicDictionary = new Dictionary<string, CheckLogic>();

        public LogicResolver(LogicHeader logicHeader)
        {
            foreach (var logic in logicHeader.Logic)
                _logicDictionary.Add(logic.Id, logic);
            foreach (var checkLogic in CheckLogicMethod.LoadDefault())
                _checkLogicDictionary.Add(checkLogic.Id, checkLogic);
        }

        private Logic.Logic FindLogic(CheckLogic check)
        {
            Logic.Logic logic;
            if (!_logicDictionary.TryGetValue(check.Id, out logic))
            {
                Debug.WriteLine("Unable to find logic for check: " + check.Id);
                return null;
            }
            return logic;
        }

        private Logic.Logic FindLogic(ItemLogic check)
        {
            /*
            Logic.Logic logic;
            if (!_logicDictionary.TryGetValue(check.Name, out logic))
            {
                Debug.WriteLine("Unable to find logic for item: " + check.Name);
                return null;
            }
            return logic;
            */
            return null;
        }

        public void UpdateCheckForItem(Dictionary<string, ItemLogic> items)
        {
            // We receive a new list of item, we will see if we can update every check available
            foreach (var check in _checkLogicDictionary.Values)
                UpdateCheck(items, check);
        }

        private void UpdateCheck(Dictionary<string, ItemLogic> items, CheckLogic check)
        {
            var checkLogic = FindLogic(check);
            if (checkLogic == null)
                return;
            
        }

        private bool IsLogicValidate(Dictionary<string, ItemLogic> items, Logic.Logic logic)
        {
            // Check the logic if the condition to make the logic are true
            return false;
        }
    }
}
