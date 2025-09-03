lexer grammar DiceScript20Lexer;

channels { COMMENTS_CHANNEL }

/*
 * Lexer Rules
 */

SINGLE_LINE_COMMENT
	: '//' INPUT_CHARACTER* -> channel(COMMENTS_CHANNEL);

DELIMITED_COMMENT
	: '/*' .*? '*/' -> channel(COMMENTS_CHANNEL);

WS
	:	[ \t\r\n] -> channel(HIDDEN)
	;

COMMA
	: ',';

EXPLODE
	: '!';

COMPOUND
	: '!!';

PENETRATION
	: '!' P;

LEFT_BRACKET
	: '[';

RIGHT_BRACKET
	: ']';

VALUE
	: '@{' -> pushMode(SUBSTITUTION);

LEFT_CURLY_BRACE
	: '{';

RIGHT_CURLY_BRACE
	: '}';

LEFT_PARENTHESIS
	: '(';

RIGHT_PARENTHESIS
	: ')';

INLINE_START
	: '[[';

INLINE_STOP
	: ']]';

PLUS
	: '+';

MINUS
	: '-';

MULTIPLY
	: '*';

DIVIDE
	: '/';

EXPONENTIATION
	: '**';

MODULUS
	: '%';

EQUAL
	: '=';

POUND
	: '#';

QMARK
	: '?';

AMPERSAND
	: '&';

COLON
	: ':';

SEMI
	: ';';

PIPE
	: '|';

MAX
	: M A X;

OP_SUM_TARGET
	: '+#';

OP_SUM_GREATER_THAN
	: '+>';

OP_SUM_LESS_THAN
	: '+<';

OP_LESS_THAN
	: '<';

OP_GREATER_THAN
	: '>';

UNDERSCORE
	: '_';

REROLL
	: R;

REROLL_ONCE
	: R O;

FAILURE
	: F;

CRITICAL_SUCCESS
	: C S;

CRITICAL_FAILURE
	: C F;

FATE_DIE_CODE
	: D F;

BASIC_DIE_CODE
	: D;

SPECIALTY_DIE_CODE
	: D '-' (LETTER | DIGIT) (LETTER | DIGIT | UNDERSCORE)*;

OP_DROP_LOW
	: D L;

OP_DROP_HIGH
	: D H;

OP_KEEP_LOW
	: K L;

OP_KEEP_HIGH
	: K H;

OP_MATCH
	: M;

OP_MATCH_TRANSFORM
	: M T;

OPTIONS
	: O P T I O N S;

CRITICAL_SUCCESS_MULTIPLIER
	: C X;

BOTCH
	: B O T C H;

ALL_CRITICAL_FAILURES
	: A L L C R I T F A I L U R E S;

NET_CRITICAL_FAILURES
	: N E T C R I T F A I L U R E S;

SUBTRACT_CRITICAL_FAILURES_FROM_SUCCESSES
	: S U B T R A C T C R I T I C A L F A I L U R E S F R O M S U C C E S S E S;

NUMBER
	: DIGIT+;

FLOAT
	: DIGIT+ [.] DIGIT+ (EXPONENTNOTATION EXPONENTSIGN DIGIT+)?
	| DIGIT+ EXPONENTNOTATION EXPONENTSIGN DIGIT+
	;

IDENTIFIER
	: (LETTER | UNDERSCORE) (LETTER | DIGIT | UNDERSCORE)* {_input.La(1) == '('}?
	;

LETTER
	: LOWERCASE
	| UPPERCASE
	;

/*
 * Lexer mode for handling substitution values
 */

mode SUBSTITUTION;

CLOSE_VALUE
	: '}' -> popMode;

IDENTIFIER2
	: (LETTER2 | UNDERSCORE) (LETTER2 | DIGIT | '_')* -> type(IDENTIFIER)
	;

LETTER2
	: (LOWERCASE | UPPERCASE) -> type(LETTER)
	;

/*
 * fragments
 */

fragment LOWERCASE
	: [a-z] ;

fragment UPPERCASE
	: [A-Z] ;

fragment EXPONENTNOTATION
	: ('E' | 'e');

fragment EXPONENTSIGN
	: ('-' | '+');

fragment DIGIT
	: [0-9] ;

fragment ESC
	: '\\"' | '\\\\' ;

fragment INPUT_CHARACTER
	: ~[\r\n\u0085\u2028\u2029];

fragment A : [aA];
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];