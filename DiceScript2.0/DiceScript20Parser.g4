parser grammar DiceScript20Parser;

options { tokenVocab=DiceScript20Lexer; }

/*
 * Parser Rules
 */

script
	: optionSet? expression;

expression
	: subExpression																							#SubstitutionExpression
	| functionCall																							#FunctionExpression
	| '(' expression ')'																					#ParenthesisExpression
	| diceRoll																								#DiceRollExpression
	| expression '?' numericExpression? '&' operator=('+' | '-' | '*' | '/') expression						#ConditionalExpression
	| expression '**' expression																			#EponentiationExpression
	| expression operator=('*' | '/' | '%') expression														#MultiplyDivideModulusExpression
	| expression operator=('+' | '-') expression															#AddSubtractExpression
	| PIPE expression PIPE																				#AbsoluteExpression
	| numericExpression																						#NumberExpression
	| FLOAT																									#FloatingPointExpression
	;

diceRoll
	: groupedExpression																						#GroupedResultExpression
	| diceRoll '!' optionValue? (MAX numericExpression)?													#ExplodingDiceExpression
	| diceRoll '!!' optionValue? (MAX numericExpression)?													#CompoundingDiceExpression
	| diceRoll PENETRATION ('>' numericExpression)?															#PenetrationExpression
	| diceRoll OP_KEEP_HIGH numericExpression																#KeepHighExpression
	| diceRoll OP_DROP_LOW numericExpression																#DropLowExpression
	| diceRoll OP_KEEP_LOW numericExpression																#KeepLowExpression
	| diceRoll OP_DROP_HIGH numericExpression																#DropHighExpression
	| diceRoll REROLL optionValue? (MAX numericExpression)?													#RerollExpression
	| diceRoll REROLL_ONCE optionValue?																		#RerollOnceExpression
	| diceRoll CRITICAL_SUCCESS optionValue (CRITICAL_FAILURE optionValue)?									#CriticalSuccessFailureExpression
	| diceRoll targetCompare numericExpression (FAILURE targetCompare numericExpression)?					#SuccessesExpression
	| diceRoll CRITICAL_SUCCESS_MULTIPLIER optionValueNumber												#CriticalSuccessMultiplierExpression
	| modifiedDice																							#ModifiedDiceExpression
	| basicDice																								#BasicDiceExpression
	| fateDice																								#FateDiceExpression
	| specialtyDice																							#SpecialtyDiceExpression
	;

optionSet
	: OPTIONS ':' option+;

option
	: (criticalSuccessOption | criticalFailureOption | criticalSuccessMultiplier | successesBotchOption | SUBTRACT_CRITICAL_FAILURES_FROM_SUCCESSES) SEMI;

criticalSuccessMultiplier
	: CRITICAL_SUCCESS_MULTIPLIER optionValueNumber;

criticalSuccessOption
	: BASIC_DIE_CODE numericExpression CRITICAL_SUCCESS optionValue;

criticalFailureOption
	: BASIC_DIE_CODE numericExpression CRITICAL_FAILURE optionValue;

successesBotchOption
	: BOTCH '=' (ALL_CRITICAL_FAILURES | NET_CRITICAL_FAILURES);

optionValueNumber
	: numericExpression
	| '=' numericExpression
	;

optionValueNumberSet
	: numericExpression
	| '=' numericExpression
	| '=' numericSet
	;

optionValue
	: numericExpression
	| compare numericExpression
	| '=' numericSet
	;

numericSet
	: '(' numericExpression (COMMA numericExpression)*? ')';

compare
	: ('<' | '>' | '=');

targetCompare
	: ('<' | '>' | '=' | '#' | '+#' | '+>' | '+<');

functionCall
	: IDENTIFIER '(' (expression (COMMA expression)*?)? ')';

modifiedDice
	: '[' basicDice operator=('*' | '/' | '+' | '-') numericExpression ']';

inline
	: '[[' expression ']]';

subExpression
	: VALUE IDENTIFIER CLOSE_VALUE;

groupedExpression
	: LEFT_CURLY_BRACE expression (COMMA expression)*? RIGHT_CURLY_BRACE;

basicDice
	: numericExpression BASIC_DIE_CODE numericExpression;

fateDice
	: numericExpression FATE_DIE_CODE;

specialtyDice
	: numericExpression SPECIALTY_DIE_CODE;

numericExpression
	: inline
	| NUMBER
	;