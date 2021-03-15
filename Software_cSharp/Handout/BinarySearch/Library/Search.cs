using System;

namespace Library {
    public static class Search {
        //The ambiguity is either that the algorithm is amazingly fast, since it is not when the element is not in the list.
        //Else the ambiguity is "comparable elements", whereas a duplicate element is not comparable.
        //it is not possible to find a difference between 4 and 4 no matter where in the list they are placed.
        //fixed this by returning the low variable when the target was found.
        public static int Binary(IComparable[] array, IComparable target) {
            if (array.Length > 0) {
                var low = 0;
                var high = array.Length - 1;
                //checks the last and first element to see if target can be inbetween
                if (array[0].CompareTo(target) <= 0 && array[high].CompareTo(target) >= 0) {
                    while (low < high) { //only less than now
                        var mid = low + (high - low)/2; //(high + low) / 2 - can also be low/2 + high/2
                        var midVal = array[mid]; //redundant, midVal can be replaced by array[mid] in relation
                        var relation = midVal.CompareTo(target);

                        if (relation < 0) {
                            low = mid + 1;
                        } else {
                            high = mid;
                        }
                    }
                    if (array[low].CompareTo(target) == 0) { //avoid returning low if low isn't equal to target
                        return low;
                    }
                    return -1;
                }
                return -1;
            }
            return -1;
        }

        public static int Jump(IComparable[] array, IComparable target) {
            int arrLength = array.Length;
            int jumpLength = System.Convert.ToInt32(System.Math.Sqrt(array.Length));
            int last = 0;
            //finds which jump the target is between.
            while (array[Math.Min(arrLength, jumpLength) - 1].CompareTo(target) == -1 ) { //same as while(array[Math.Min(arrLength, jumpLength) - 1] < (int)target)
                last = jumpLength;
                jumpLength += System.Convert.ToInt32((Math.Sqrt(arrLength)));
                if (last >= arrLength) {return -1;}
            }
            //linear search from the last jump until the end of the array or next jump is met
            while (array[last].CompareTo(target) == -1) { //same as above. This is done since target is an Icomparable.
                last++;
                if (last == Math.Min(jumpLength,arrLength)) {
                    return -1;
                }
            }
            //if the target is found
            if (array[last].CompareTo(target) == 0) {
                return last;
            }
            return -1;
        }
    }
}