using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIILab1
{
    class SemanticNet
    {
        List<string> notions = new List<string>();
        List<string> relations = new List<string>();

        Dictionary<string, string> relationsAirplane =new Dictionary<string, string>();
        Dictionary<string, string> relationsBoing = new Dictionary<string, string>();
        Dictionary<string, string> relationsMotor = new Dictionary<string, string>();
        Dictionary<string, string> relationsSokol = new Dictionary<string, string>();
        Dictionary<string, string> relationsOrel = new Dictionary<string, string>();
        Dictionary<string, string> relationsBird = new Dictionary<string, string>();

        Dictionary<string, Dictionary<string, string>> notionsAndRelations = new Dictionary<string, Dictionary<string, string>>();



        public SemanticNet()
        {
            notions.Add("Самолет");         //0
            notions.Add("Боинг-747");       //1
            notions.Add("Мотор");           //2
            notions.Add("Пилот");           //3
            notions.Add("Бензин");          //4
            notions.Add("Летать");          //5
            notions.Add("Крылья");          //6
            notions.Add("Сокол");           //7
            notions.Add("Орел");            //8
            notions.Add("Клюв");            //9
            notions.Add("Оперение");        //10
            notions.Add("Птица");           //11
            notions.Add("Аэродинамические");//12

            relations.Add("Является");          //0
            relations.Add("Имеет");             //1
            relations.Add("Умеет");             //2
            relations.Add("Использует");        //3
            relations.Add("Планирующий полет"); //4
            relations.Add("Светлое");           //5
            relations.Add("Широкие");           //6

            relationsAirplane.Add(notions[6], relations[1]);
            relationsAirplane.Add(notions[5], relations[2]);
            relationsAirplane.Add(notions[2], relations[1]);
            relationsAirplane.Add(notions[12], relations[3]);

            relationsBoing.Add(notions[0], relations[0]);

            relationsMotor.Add(notions[3], relations[1]);
            relationsMotor.Add(notions[4], relations[3]);

            relationsSokol.Add(notions[11], relations[0]);

            relationsOrel.Add(notions[5], relations[2]);
            relationsOrel.Add(notions[6], relations[6]);
            relationsOrel.Add(notions[11], relations[0]);
            relationsOrel.Add(notions[10], relations[5]);
            relationsOrel.Add(notions[9], relations[1]);
            relationsOrel.Add(notions[12], relations[4]);

            relationsBird.Add(notions[5], relations[2]);
            relationsBird.Add(notions[12], relations[3]);
            relationsBird.Add(notions[10], relations[1]);
            relationsBird.Add(notions[9], relations[1]);

            notionsAndRelations.Add(notions[0], relationsAirplane);
            notionsAndRelations.Add(notions[1], relationsBoing);
            notionsAndRelations.Add(notions[2], relationsMotor);
            notionsAndRelations.Add(notions[7], relationsSokol);
            notionsAndRelations.Add(notions[8], relationsOrel);
            notionsAndRelations.Add(notions[11], relationsBird);

        }

        public string GetLinkedNotions(string notion, string relation)
        {
            string inputString = "";
            Dictionary<string, string> tempDict = new Dictionary<string, string>();
            if (notionsAndRelations.ContainsKey(notion))
            {
                notionsAndRelations.TryGetValue(notion, out tempDict);
                foreach (var item in tempDict)
                {
                    if(item.Value == relation)
                    {
                        inputString += notion + " " + item.Value  + " " + item.Key + Environment.NewLine;
                    }
                }
                return inputString;
            }
            return "Отношений нет";
        }

        public string GetRelations(string notion)
        {
            string inputString = "";
            Dictionary<string, string> tempDict = new Dictionary<string, string>();

            if (notionsAndRelations.ContainsKey(notion))
            {
                notionsAndRelations.TryGetValue(notion, out tempDict);
                Dictionary<string, string>.ValueCollection relationsColl = tempDict.Values;
                foreach (string item in relationsColl)
                {
                    inputString += item + ", ";
                }
                return inputString;
            }
            return "Отношений нет";
        }

        public string GetNotionsPairs(string relation)
        {
            string inputString = "";
            Dictionary<string, string> tempDict = new Dictionary<string, string>();
            foreach (var notionAndRelation in notionsAndRelations)
            {
                tempDict = notionAndRelation.Value;
                foreach (var item in tempDict)
                {
                    if (item.Value == relation)
                    {
                        inputString += notionAndRelation.Key + " " + relation + " " + item.Key + Environment.NewLine;
                    }
                }

            }
            return inputString;
        }

        public string GetRoad(string notionStart, string notionEnd)
        {
            string inputString = notionStart + " ----> ";
            string tempNotion = notionStart;

            Stack<string> notionStack = new Stack<string>();
            
            Search(ref notionStack, tempNotion, notionEnd);
			foreach (var item in notionStack)
			{
                if(item != notionEnd)
                    inputString += item + " ----> ";
                else
                    inputString += item;

            }		            
            return inputString;           
        }
        private string Search(ref Stack<string> notionStack, string tempNotion, string notionEnd)
        {
            if (tempNotion == notionEnd)
            {
                return notionEnd;
            }

            Dictionary<string, string> tempDict = new Dictionary<string, string>();
            notionsAndRelations.TryGetValue(tempNotion, out tempDict);
            string notionFind = null;
            if (tempDict != null)
            {
                
                foreach (var item in tempDict)
                {

                    notionFind = Search(ref notionStack, item.Key, notionEnd);
                    if (notionFind != null)
                    {

                        notionStack.Push(item.Key);
                        break;
                    }
                }
            }

                return notionFind;           
        }

    }

}
