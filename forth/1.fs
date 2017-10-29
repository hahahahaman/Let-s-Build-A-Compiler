\ Variable Declaration

0 VALUE Look \ lookahead character

\ Tools

\ : >UPC 95 AND ; \ uppercase

: tab 4 spaces ; \ don't know what tab character is in forth

\ read new character from input
: getchar ( -- ) EKEY TO Look ;

\ report an error
: error ( c-addr u -- ) CR 7 EMIT ." Error: " TYPE ." ." ;

\ report an error and stops
: aborts ( c-addr u --) error ABORT ;

\ report what was expected
: expected ( c-addr u -- )
    pad place \ put into pad
    s"  Expected" pad +place \ concatenate strings and store in pad
    pad count aborts ; \ send pad to aborts

\ recognize an alpha character
: alpha? ( char -- tf ) TOUPPER 'A' 'Z' 1+ WITHIN ;

\ recognize a decimal digit
\ : digit? ( char -- tf ) '0' '9' 1+ WITHIN ;

\ output a string with tab
: emits ( c-addr u -- ) tab EMIT TYPE ;

\ output a string with tab and newline
: emitln ( c-addr u -- ) CR emits ;

\ initialize
: init ( -- ) getchar ;

\ Specifics ---------------------------------

\ match a specific input character
: match ( char -- )
    DUP Look =
    IF DROP getchar
    ELSE
        \ error, don't match 
        20 allocate drop \ allocate string, pop error value
        ''' over c$+! \ append ' character
        Look over c$+! \ append Look character
        ''' over c$+! \ append ' character
        dup
        $@ expected 
    ENDIF ;

\ get an identifier
: getname ( -- char )
    Look alpha? 0=
    IF s" Name" expected ENDIF
    Look TOUPPER
    getchar ;

\ get a number
: getnum ( -- char )
    Look digit? 0= IF s" Integer" expected ENDIF
    Look '0' -
    getchar ;

\ Main Program
: cradle ( -- ) init ;