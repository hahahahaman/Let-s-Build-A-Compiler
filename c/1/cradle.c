/* boiler plate stuff: input and output, error messages, etc. */

#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

/*
#define UPCASE(C) (~(1<<5) & (C))

  what is this?

  ok apparently all lowercase letters have the 6th bit from left set
  to 1 (1XXXXX). This macro sets the 6th bit to 0 shifting C's value
  by 32 positions, which is the difference between uppercase and
  lowercase letters in ASCII.

  this will work for lowercase letters, and will never change an
  uppercase letter.

*/
#define MAX_BUF 100

char tmp[MAX_BUF];
char Look;

// Read a new character from Input into Look.
void GetChar(){
  Look = getchar();
}

// Report error.
void Error(char *s){
  printf("\nError: %s.\n", s);
}

// Report error and stop.
void Abort(char *s){
  Error(s);
  exit(1);
}

// Report what was expected.
void Expected(char *s){
  sprintf(tmp, "%s Expected", s);
  Abort(tmp);
}

// Match a specific input character.
void Match(char x){
  if(Look == x){
    GetChar();
  } else {
    sprintf(tmp, "' %c ' ", x);
    Expected(tmp);
  }
}

// Check if alphabetic character.
int IsAlpha(char c){
  return (toupper(c) >= 'A') && (toupper(c) <= 'Z');
}

// Check if decimal digit.
int IsDigit(char c){
  return (c >= '0') && (c <= '9');
}

// Get an identifier.
char GetName(){
  char c = Look;
  if(!IsAlpha(Look)){
    sprintf(tmp, "Name");
    Expected(tmp);
  }

  GetChar();
  return c;
}

// Get a number.
char GetNum(){
  char c = Look;

  if(!IsDigit(Look)){
    sprintf(tmp, "Integer");
    Expected(tmp);
  }

  GetChar();
  return c ;
}

// Output a string with a tab.
void Emit(char *s){
  printf("\t%s", s);
}

// Output a string with a tab and endline.
void EmitLn(char *s){
  Emit(s);
  printf("\n");
}

// Initialization.
void Init(){
  GetChar();
}

int main(int argv, char** argc){
  Init();

  return 0;
}
