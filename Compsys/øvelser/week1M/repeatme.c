#include <stdio.h>

int main(int argc, char* argv[]) {
    if ((argc - 1) >= 2) {
        printf("Wrong number of arguments. \nPlease only give 1 argument. \nYour amount of arguments: %d\n", (argc - 1));
    } else {
        printf("%s\n%s\n", argv[1], argv[1]);
    }
}