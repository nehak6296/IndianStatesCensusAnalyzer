using IndianStatesCensusAnalyzer;
using IndianStatesCensusAnalyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyzer.CensusAnalyser;

namespace NUnitTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndianStateCensusCsvData.csv";
        static string IncorrectIndianStateCensusFileName = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndianStateCensusCsvData1.csv";
        static string CorrectIndianStateCensusFileButTypeIncorrect = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndianStateCensusCsvData.txt";
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFile = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\WrongIndiaStateCensusData.csv";

        static string indianStateCodeFilePath = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndiaStateCode.csv";
        static string CorrectIndiaStateCodeFileButTypeIncorrect = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndiaStateCode.txt";
        static string wrongIndianStateCodeFileType = @"";
        static string delimiterIndianStateCodeFilePath = @"";
        static string wrongHeaderStateCodeFilePath = @"";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]  //TC1.1
        public void GivenIndianStateCensusCsvDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        [Test]  //TC1.2
        public void GivenIncorrectIndianCensusDataFileName_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndianStateCensusFileName, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        [Test]  //TC1.3
        public void GivenCorrectIndianCensusDataFileNameWithIncorrectExtension_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CorrectIndianStateCensusFileButTypeIncorrect, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        [Test]  //TC1.4
        public void GivenDelimiterInorrectIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]  //TC1.5
        public void GivenWrongHeaderIndianStateCensusData_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFile, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
        [Test]  //TC2.1
        public void GivenIndianStateCodeFileData_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]  //TC2.3
        public void GivenCorrectIndianStateCodeFileName_But_Extension_Incorrect_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CorrectIndiaStateCodeFileButTypeIncorrect, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
    }
}