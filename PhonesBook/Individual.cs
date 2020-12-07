using System.Collections.Generic;

    class Individual : PhoneBook
    {
        public Individual(List<string> dataList, List<PhoneBook> phoneBook) : base(dataList[0], dataList[1], dataList[2], phoneBook)
        {
            if (dataList.Count > 3) Address = dataList[3];
        }

        public override string ToString()
        {
            return $"First name : {FirstName}\nLast Name : {LastName}\nPhone Number : {PhoneNumber}\nAddress : {Address ?? "None"}";
        }

    }
