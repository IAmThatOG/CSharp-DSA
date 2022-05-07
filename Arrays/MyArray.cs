using System;
using System.Text.Json;

namespace Arrays
{
    public class MyArray
    {
        public uint Length { get; private set; }
        public object[] Data { get; private set; }

        public MyArray()
        {
            Length = 0;
            Data = new object[1];
        }

        public object Get(uint index)
        {
            return Data[index];
        }

        public uint Push(object item)
        {
            //create a new array with an increased _length
            Length++;
            var temp = new object[Length];
            //copy the old array into the new array
            Array.Copy(Data, temp, Data.Length);
            //push item
            temp[Length - 1] = item;
            //assign new array to _data field
            Data = new object[Length];
            Array.Copy(temp, Data, Length);
            //increment length
            return Length;
        }

        public object Pop()
        {
            //decrease Length
            Length--;
            //get last element
            var lastItem = Data[Length];
            //copy the old array into the new array
            var temp = new object[Length];
            Array.Copy(Data, temp, Length);
            //create new Data array of new reduced length
            Data = new object[Length];
            //copy temp array into new data array
            Array.Copy(temp, Data, Length);
            //return last element
            return lastItem;
        }

        public void Delete(uint index)
        {
            if (index >= Length)
            {
                throw new IndexOutOfRangeException($"Index ({index}) is greater than the last index ({Length - 1}) of the array");
            }
            var item = Data[index];
            for (uint i = index; i < Length - 1; i++)
            {
                Data[i] = Data[i + 1];
            }
            Length--;
            var temp = new object[Length];
            Array.Copy(Data, temp, Length);
            //create new Data array of new reduced length
            Data = new object[Length];
            //copy temp array into new data array
            Array.Copy(temp, Data, Length);
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}