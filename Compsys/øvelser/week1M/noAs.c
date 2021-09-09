#include <stdio.h>

int main(int argc, char* argv[]) {
    if ((argc - 1) >= 2) {
        printf("Wrong number of arguments. \nPlease only give 1 argument. \nYour amount of arguments: %d\n", (argc - 1));
    } else {
        char* arg = argv[1];
        if (arg[0] == 'A' || arg[0] == 'a') { //same as switch looking at arg[0] matching with a and A + default case
            printf("No beginning A's are allowed\n");
        } else {
            printf("%s\n", argv[1]);
        }
    }
}