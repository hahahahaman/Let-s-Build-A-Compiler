\ Variable Declaration

0 VALUE Look \ lookahead character

\ Tools

: >UPC 95 AND ; \ what does this do?

: tab 4 spaces ; \ don't know what tab character is in forth

\ read new character from input
: getchar ( -- ) EKEY TO Look ;

\ report an error
: error ( c-addr -- ) CR 7 EMIT ." Error: " TYPE ." ." ;

\ report an error and stops
: aborts ( c-addr --) error ABORT ;

\ report what was expected
: expected ( c-addr -- )
    pad place \ puts the c-addr in storage
    s"  Expected" pad +place \ concatenate strings and store in pad
    pad aborts ; \ send pad to aborts

\ recognize an alpha character
: alpha? ( char -- tf ) >UPC 'A' 'Z' 1+ WITHIN ;

\ recognize a decimal digit
: digit? ( char -- tf ) '0' '9' 1+ WITHIN ;

\ output a string with tab
: emits ( c-addr u -- ) tab EMIT TYPE ;

\ output a string with tab and newline
: emitln ( c-addr u -- ) CR emits ;

\ initialize
: init ( -- ) getchar ;

\ Specifics

\ match a specific input character

\ get an identifier

\ get a number

\ Main Program
: cradle ( -- ) init ;