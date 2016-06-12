Feature: ReservedWords
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Input is Empty
	Given I have an input of ''
	When We Tokenize
	Then the result should be 
		| Type		| Lexeme   | Column | Row |
		| EOF	    | $	       |   0    | 0   |

Scenario: Input is an id equal to haloword
	Given I have an input of '<%haloworld'
	When We Tokenize
	Then the result should be 
		| Type		| Lexeme   | Column | Row |
		| ID	    | haloworld|   2    | 0   |
		| EOF	    | $	       |   11   | 0   |
	
Scenario: Input is 2 ids with whitespaces
	Given I have an input of '<%halo warudo'
	When We Tokenize
	Then the result should be 
		| Type		| Lexeme   | Column | Row |
		| ID	    | halo     |   2    | 0   |
		| ID	    | warudo   |   7    | 0   |
		| EOF	    | $	       |   13   | 0   |

Scenario: Input is an int equal to 2042
	Given I have an input of '<%2042'
	When We Tokenize
	Then the result should be 
		| Type			| Lexeme   | Column | Row |
		| NUMBER_LITERAL| 2042     |   2    | 0   |
		| EOF			| $	       |   6    | 0   |

Scenario: Input is an int and an a 2042
	Given I have an input of '<%2042a'
	When We Tokenize
	Then the result should be 
		| Type			| Lexeme   | Column | Row |
		| NUMBER_LITERAL| 2042     |   2    | 0   |
		| ID			| a		   |   6    | 0   |
		| EOF			| $	       |   7    | 0   |

Scenario: Input is an id a2042
	Given I have an input of '<%a2042'
	When We Tokenize
	Then the result should be 
		| Type		| Lexeme   | Column | Row |
		| ID		| a2042	   |   2    | 0   |
		| EOF	    | $	       |   7    | 0   |

 Scenario: Input is an Addition operator
	Given I have an input of '<%+'
	When We Tokenize
	Then the result should be 
		| Type		| Lexeme   | Column | Row |
		| SUM		| + 	   |   2    | 0   |
		| EOF	    | $	       |   3	| 0   |

 Scenario: Input is a KeyWord
	Given I have an input of '<%integer num;'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme   | Column | Row |
		| ID				| integer  |   2    | 0   |
		| ID				| num	   |   10   | 0   |
		| EOS				| ;	       |   13	| 0   |
		| EOF				| $	       |   14	| 0   |

 Scenario: Input is a String Literal
	Given I have an input of '<%'integer num''
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| STRING_LITERAL	| 'integer num' |   2    | 0   |
		| EOF				| $				|   15	 | 0   |

Scenario: Input is a hexadecimal Number
	Given I have an input of '<%$FF09'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| NUMBER_LITERAL	| 65289			|   2    | 0   |
		| EOF				| $				|   7	 | 0   |

Scenario: Input is a binary num
	Given I have an input of '<%%0101'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| NUMBER_LITERAL	| 5				|   2    | 0   |
		| EOF				| $				|   7	 | 0   |

Scenario: Input is a octal num
	Given I have an input of '<%&07121'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| NUMBER_LITERAL	| 3665			|   2    | 0   |
		| EOF				| $				|   8	 | 0   |

Scenario: Input is a binary assign num
	Given I have an input of '<%integer bin := %0101;'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| ID				| integer		|   2    | 0   |
		| ID				| bin			|   10	 | 0   |
		| TK_ASSIGN			| :=			|   14   | 0   |
		| NUMBER_LITERAL	| 5				|   17	 | 0   |
		| EOS				| ;				|   22   | 0   |
		| EOF				| $				|   23	 | 0   |

Scenario: Input is a less equal than
	Given I have an input of '<%345 <= 365'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| NUMBER_LITERAL	| 345			|   2    | 0   |
		| LESS_EQUAL		| <=			|   6	 | 0   |
		| NUMBER_LITERAL	| 365			|   9	 | 0   |
		| EOF				| $				|   12	 | 0   |

Scenario: Input is a greater equal than
	Given I have an input of '<%345 >= 365'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| NUMBER_LITERAL	| 345			|   2    | 0   |
		| GREATER_EQUAL		| >=			|   6	 | 0   |
		| NUMBER_LITERAL	| 365			|   9	 | 0   |
		| EOF				| $				|   12	 | 0   |

Scenario: Input is not equal 
	Given I have an input of '<%345 <> 365'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| NUMBER_LITERAL	| 345			|   2    | 0   |
		| NOT_EQUAL			| <>			|   6	 | 0   |
		| NUMBER_LITERAL	| 365			|   9	 | 0   |
		| EOF				| $				|   12	 | 0   |

Scenario: Input is an assigned array 
	Given I have an input of '<%myArray := array[1..10] of integer;'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| ID				| myarray		|   2    | 0   |
		| TK_ASSIGN			| :=			|   10	 | 0   |
		| KW_ARRAY			| array			|   13	 | 0   |
		| TK_LEFTBRACKET	| [				|   18	 | 0   |
		| NUMBER_LITERAL	| 1				|   19	 | 0   |
		| TK_RANGE			| ..			|   20	 | 0   |
		| NUMBER_LITERAL	| 10			|   22	 | 0   |
		| TK_RIGHTBRACKET	| ]				|   24	 | 0   |
		| KW_OF				| of			|   26	 | 0   |
		| ID				| integer		|   29	 | 0   |
		| EOS				| ;				|   36	 | 0   |
		| EOF				| $				|   37	 | 0   |

Scenario: Input is relational operators 
	Given I have an input of '<%'ham' < 'tam' and or not 'tam' > 'ham''
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| STRING_LITERAL	| 'ham'			|   2    | 0   |
		| LESS_THAN			| <				|   8	 | 0   |
		| STRING_LITERAL	| 'tam'			|   10	 | 0   |
		| KW_AND			| and			|   16	 | 0   |
		| KW_OR				| or			|   20	 | 0   |
		| KW_NOT			| not			|   23	 | 0   |
		| STRING_LITERAL	| 'tam'			|   27   | 0   |
		| GREATER_THAN			| >			|   33	 | 0   |
		| STRING_LITERAL	| 'ham'			|   35	 | 0   |
		| EOF				| $				|   40	 | 0   |


Scenario: Input access token and range token
	Given I have an input of '<%. ..'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| TK_ACCESS			| .				|   2    | 0   |
		| TK_RANGE			| ..			|   4	 | 0   |
		| EOF				| $				|   6	 | 0   |

Scenario: Input multiline comment with braces
	Given I have an input of '<%{*hey**hey*}'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| EOF				| $				|   14	 | 0   |

Scenario: Input multiline comment with parenthesis
	Given I have an input of '<%(*hey**hey*)'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme		| Column | Row |
		| EOF				| $				|   14	 | 0   |

Scenario: Input expression inside parenthesis
	Given I have an input of '<%(32*20)'
	When We Tokenize
	Then the result should be 
		| Type                | Lexeme | Column | Row |
		| TK_LEFTPARENTHESIS  | (      | 2      | 0   |
		| NUMBER_LITERAL      | 32     | 3      | 0   |
		| MULT                | *      | 5      | 0   |
		| NUMBER_LITERAL      | 20     | 6      | 0   |
		| TK_RIGHTPARENTHESIS | )      | 8      | 0   |
		| EOF                 | $	   | 9		| 0   |

Scenario: Input single line comment with doble slash
	Given I have an input of '<%//(*hey**hey*)'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme			| Column | Row |
		| EOF				| $					|   16	 | 0   |

Scenario: Input html pascal html pascal
	Given I have an input of '<html><%%><html><%%>'
	When We Tokenize
	Then the result should be 
		| Type				| Lexeme			| Column | Row |
		| HTML				| <html>			|   0    | 0   |
		| HTML				| <html>			|   10   | 0   |
		| EOF				| $					|   20	 | 0   |