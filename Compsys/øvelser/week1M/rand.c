#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>

int checker(int);
int main( ) {

    srand(time(NULL));
    int x = rand() % 50;
    

    printf("Lets play a game! I think of a number and you have to guess it! \n\nready? no? too bad bisch here we go :\n");
    checker(x);
    
}

int checker(int n) {
    int guess;
    if (scanf("%d", &guess) == 1) {
        if (guess > n) {
            printf("Too high\n");
            checker(n);
        } else if (guess < n) {
            printf("Too low\n");
            checker(n);
        } else {
            printf("BITCH YOU GUESSED IT!!!\n");
        }
    }
    else {
        printf("You've entered a wrong type of input. Please only enter numbers such as \"1\" or \"5\"\n");
        while (scanf("%d", &guess) != 1) {
            getchar(); //causes a small bug, user needs to input a number before the while loop breaks and checker calls itself again
        }
        checker(n);
    }
    return 0;
}


