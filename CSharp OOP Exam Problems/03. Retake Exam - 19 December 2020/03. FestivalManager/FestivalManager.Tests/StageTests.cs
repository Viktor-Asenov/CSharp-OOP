namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void ConstructorShouldInitializeStageCorrectly()
	    {
			Stage stage = new Stage();

			int expectedCount = 0;
			int actualCount = stage.Performers.Count;

			Assert.AreEqual(expectedCount, actualCount);
		}

		[Test]
		public void AddPerformerShouldThrowArgumentNullExceptionWhenPerformerIsNull()
        {
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

		[Test]
		public void AddPerformerShouldThrowArgumentExceptionWhenPerformerIsUnderEighteen()
		{
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Ivan", "Ivanov", 15)));
		}


		[Test]
		public void AddPerformerShouldWorkProperlyAndIncreaseCountOfPerformers()
		{
			Stage stage = new Stage();
			stage.AddPerformer(new Performer("Ivan", "Ivanov", 18));

			int expectedCount = 1;
			int actualCount = stage.Performers.Count;

			Assert.AreEqual(expectedCount, actualCount);
		}

		[Test]
		public void AddSongShouldThrowArgumentNullExceptionWhenSongIsNull()
		{
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void AddSongShouldThrowArgumentExceptionWhenSongIsUnderOneMinute()
		{
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Melnik", TimeSpan.Zero)));
		}

		[TestCase(null, "Kiril")]
		[TestCase("Melnik", null)]
		public void AddSongToPerformerShouldThrowArgumentNullExceptionWhenSongOrPerformerIsNull(string songName, string performerName)
		{
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(songName, performerName));
		}

		[Test]
		public void GetPerformerShouldThrowArgumentExceptionWhenPerformerIsNull()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Raiko", "Kirilov", 70);
			stage.AddPerformer(performer);
			Song song = new Song("Melnik", TimeSpan.FromMinutes(2.40));
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "Pesho"));
		}

		[Test]
		public void GetPerformerShouldThrowArgumentExceptionWhenSongIsNull()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Raiko", "Kirilov", 70);
			stage.AddPerformer(performer);
			Song song = new Song("Melnik", TimeSpan.FromMinutes(2.40));
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(" ", performer.FullName));
		}

		[Test]
		public void GetPerformerShouldReturnPerformerCorrectlyAndAddSongToPerformerShouldAddtheSongAndReturnMessage()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Raiko", "Kirilov", 70);
			stage.AddPerformer(performer);
			Song song = new Song("Melnik", TimeSpan.FromMinutes(2.40));
			stage.AddSong(new Song("Melnik", TimeSpan.FromMinutes(2.40)));

			string expectedMessage = "Melnik (02:24) will be performed by Raiko Kirilov";
			string actualMessage = stage.AddSongToPerformer(song.Name, performer.FullName);

			Assert.AreEqual(expectedMessage, actualMessage);
		}

		[Test]
		public void PlayMethodShouldReturnCountOfPerformersAndSongsCount()
        {
			Stage stage = new Stage();
			Performer performer = new Performer("Raiko", "Kirilov", 70);
			stage.AddPerformer(performer);
			Song song = new Song("Melnik", TimeSpan.FromMinutes(2.40));
			stage.AddSong(new Song("Melnik", TimeSpan.FromMinutes(2.40)));

			stage.AddSongToPerformer(song.Name, performer.FullName);

			string expectedMessage = "1 performers played 1 songs";
			string actualMessage = stage.Play();

			Assert.AreEqual(expectedMessage, actualMessage);
		}
	}
}