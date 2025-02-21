using Chess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Tests {
	public class Chess960Tests {
		Board b = new Board(8, false);
		
		/// <summary>
		/// checks if theres enough space between the rooks for the king
		/// </summary>
		[Fact]
		public void rooksGood() {
			List<Tile> rooks = b.tilePositions('b', 'R');

			Assert.True(Math.Abs(rooks[0].Column - rooks[1].Column) > 1);
		}

		/// <summary>
		/// checks if king is between rooks
		/// </summary>
		[Fact]
		public void kingGood() {
			List<Tile> rooks = b.tilePositions('b', 'R');
			List<Tile> king = b.tilePositions('b', 'K');

			Assert.True(((rooks[0].Column < king[0].Column) || (rooks[1].Column < king[0].Column)) && ((rooks[0].Column > king[0].Column) || (rooks[1].Column > king[0].Column)));
		}

		/// <summary>
		/// checks if bishops are on opposite squares
		/// </summary>
		[Fact]
		public void bishopsGood() {
			List<Tile> bishops = b.tilePositions('b', 'B');

			bool otherIsOdd = (bishops[0].Column % 2 == 0) ? (bishops[1].Column % 2 == 0) ? false : true : (bishops[1].Column % 2 == 0) ? true : false;

			Assert.True(otherIsOdd);
		}

		/// <summary>
		/// checks if both back rows are positioned the same
		/// </summary>
		[Fact]
		public void rowsGood() {
			List<Tile> blackPieces = b.tilePositions('b', 'B');
			List<Tile> whitePieces = b.tilePositions('w', 'b');
			if ((blackPieces[0].Column != whitePieces[0].Column) || (blackPieces[1].Column != whitePieces[1].Column)) {
				Assert.True(false);
				return;
			}

			blackPieces = b.tilePositions('b', 'K');
			whitePieces = b.tilePositions('w', 'k');
			if (blackPieces[0].Column != whitePieces[0].Column) {
				Assert.True(false);
				return;
			}

			blackPieces = b.tilePositions('b', 'Q');
			whitePieces = b.tilePositions('w', 'q');
			if (blackPieces[0].Column != whitePieces[0].Column) {
				Assert.True(false);
				return;
			}

			blackPieces = b.tilePositions('b', 'R');
			whitePieces = b.tilePositions('w', 'r');
			if ((blackPieces[0].Column != whitePieces[0].Column) || (blackPieces[1].Column != whitePieces[1].Column)) {
				Assert.True(false);
				return;
			}

			blackPieces = b.tilePositions('b', 'N');
			whitePieces = b.tilePositions('w', 'n');
			if ((blackPieces[0].Column != whitePieces[0].Column) || (blackPieces[1].Column != whitePieces[1].Column)) {
				Assert.True(false);
				return;
			}

			Assert.True(true);
		}
	}
}