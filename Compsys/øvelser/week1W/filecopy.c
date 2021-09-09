#include <stdio.h>
#include <assert.h>

int main(int argc, char* argv[]) {
    assert(argc == 3);

    FILE* file = fopen(argv[1], "r");
    FILE* checktarget = fopen(argv[2], "r");
    //

    if (file && !checktarget) {
        char c;
        c = fgetc(file);
        FILE* copy = fopen(argv[2], "w+");

        while (c != EOF) {
            fprintf(copy, "%c", c);
            c = fgetc(file);
        }

        printf("File succesfully copied\n");
        return 1;
        
    } else {

        if (file) {
            printf("The target file already exists\n");
            return 0;
        } else {
            printf("The file %s was not found\n", argv[1]);
            return 0;
        }
    }

    return 0;
}