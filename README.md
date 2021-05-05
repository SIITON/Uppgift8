# Uppgift8


	   1     2     3     4     5     6     7     8     9     10		Frame#
	+-----+-----+-----+-----+-----+-----+-----+-----+-----+--+----+		
	|     |     |     |     |     |     |     |     |     |       |		Roll
	|     |     |     |     |     |     |     |     |     |       |		Score
	+-----+-----+-----+-----+-----+-----+-----+-----+-----+--+----+

Example:

	   1     2     3     4     5     6     7     8     9     10
	+-----+-----+-----+-----+-----+-----+-----+-----+-----+--+----+
	| 2  4| 7  /|    X| 9  /| 0  5|    X|    X| 8  1| 4  5| 3  / X|
	|    6|   26|   46|   56|   61|   89|  108|  117|  126|  146  |
	+-----+-----+-----+-----+-----+-----+-----+-----+-----+-------+
	Total score: 146


Logic:
	Each roll (pins knocked down) is added to an array indexed by turn, N.
	The score is calculated by following the rules.
Rules:

	Spare, roll[N] + roll[N + 1] == 10 
		Score[N] = 10 + roll[N+1]
		N += 1

	Strike, roll[N] == 10
		Score[N] = 10 + roll[N+1] + roll[N+2]
		N += 2

	Open frame, None of the above
		Score[N] = roll[N]