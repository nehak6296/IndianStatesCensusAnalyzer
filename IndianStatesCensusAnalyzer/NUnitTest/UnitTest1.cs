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
        static string indianStateCensusFilePath = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndianStateCensusCsvData.csv";
        static string IncorrectIndianStateCensusFileName = @"C:\Users\Neha\Desktop\Problems\IndianStatesCensusAnalyzer\IndianStatesCensusAnalyzer\NUnitTest\CSVFiles\IndianStateCensusCsvData1.csv";
        //static string wrongHeaderIndianCensusFile = @"er\WrongHeaderIndiaStateCensusData.csv";

        //static string CorrectIndianStateCensusFileButTypeIncorrect = @"\CSVFolder\IndiaStateCensusData.txt";
        //static string wrongDelimiterIndianCensusFilePath = @"\CSVFolder\DelimiterIndiaStateCensusData.csv";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
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
    }
}