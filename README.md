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



	Each roll (pins knocked down) is added to an array indexed by turn, N.
	The score is calculated by following in order:

	STRIKE: if roll[N] == 10
 
		Score[N] = 10 + roll[N+1] + roll[N+2]
		N += 2

	SPARE: if roll[N] + roll[N + 1] == 10 
		Score[N] = 10 + roll[N+1]
		N += 1

	OPEN FRAME
		Score[N] = roll[N]