#include <stdio.h>
#include <string.h>
#include <assert.h>
#include <stdlib.h>

int main( int argc, char* argv[]) {
    assert(argc == 2);

    char* in_message = argv[1];
    printf("Do you want to decrypt or encrypt a message? use d/e\n");

    char choice = getchar();

    char decrypt = 'd';
    char encrypt = 'e';

    while (choice != encrypt && choice!=decrypt) {
        printf("Please type either \"d\" or \"e\"\n");
        choice = getchar();
    }

    if (choice == encrypt) {

        printf("what n integer do you want to encrypt with?\n");
        int n;
        scanf("%d", &n);

        printf("encrypted message:   ");
        for(int i = 0; i <= (int)strlen(in_message); i++) {

            char c;
            c = in_message[i];

            int cPlus = (int)c + n; //convert a char in the string to its integer representative + 1

            char cPlusChar = cPlus-'0'+'0'; //convert back to char

            printf("%c",cPlusChar);
        }
    } else {

        printf("what n integer do you want to decrypt with?\n");
        int n;
        scanf("%d", &n);

        printf("decrypted message:   ");
        for(int i = 0; i <= (int)strlen(in_message); i++) {

            char c;
            c = in_message[i];

            int cMinus = (int)c - n;

            char cMinusChar = cMinus-'0'+'0'; 

            printf("%c", cMinusChar);
        }
    }
    printf("\n");
}
