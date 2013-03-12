using System.IO;
using MbUnit.Framework;

namespace roundhouse.tests.infrastructure.filesystem
{
    using roundhouse.infrastructure.filesystem;
    using developwithpassion.bdd.mbunit;

    [TestFixture]
    public class WindowsFileSystemAccessTests
    {
        [RowTest]
        [Row("utf8")]
        [Row("utf16le")]
        [Row("utf16be")]
        [Row("ansi")]
        public void should_be_able_to_read_files_with_different_formats(string format)
        {
            var sut = new WindowsFileSystemAccess ();
            var data = File.Exists(@".\infrastructure\filesystem\" + format + "encoded.txt")
                           ? sut.read_file_text(@".\infrastructure\filesystem\" + format + "encoded.txt")
                           : sut.read_file_text(@".\build_output\RoundhousE\infrastructure\filesystem\" + format + "encoded.txt");

            data.should_be_equal_to("INSERT INTO [dbo].[timmy]([value]) VALUES('Gã')");
        }
    }
}