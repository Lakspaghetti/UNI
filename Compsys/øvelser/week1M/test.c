#include <stdio.h>
int var1[10];
int var2;
int main ()
{
  int i;
  var2 = 0;
  printf ("Var 2 = %d \n", var2);
  for (i = 0; i <= 10; i++)
  {
    var1[i] = i;
  }
  for (i = 0; i <= 10; i++)
  {
    printf ("Var1[%d] = %d \n", i, var1[i]);
  }
  printf ("Var 2 = %d \n", var2);
  return 0;  
}