using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace IAC {
    public class Messwertverwaltung {

        #region Variablen & Objekte

        //*********************
        //Variablen & Objekte
        //*********************

        private MainForm mf = new MainForm();

        private List<float> TemperaturListe = new List<float>();
        private List<float> LichtListe = new List<float>();
        private List<float> FeuchtigkeitListe = new List<float>();
        private List<float> D�ngerListe = new List<float>();

        private float TemperaturIntervall;
        private float LichtIntervall;
        private float FeuchtigkeitIntervall;
        private float D�ngerIntervall;

        private float TemperaturXPosition = 0;
        public float LichtXPosition = 0;
        private float FeuchtigkeitXPosition = 0;
        private float D�ngerXPosition = 0;

        #endregion

        #region Konstruktoren

        //*********************
        //Konstruktoren
        //*********************

        public Messwertverwaltung(MainForm mf, float TemperaturIntervall, float LichtIntervall, float FeuchtigkeitIntervall, float D�ngerIntervall) {
            this.mf = mf;
            this.TemperaturIntervall = TemperaturIntervall;
            this.LichtIntervall = LichtIntervall;
            this.FeuchtigkeitIntervall = FeuchtigkeitIntervall;
            this.D�ngerIntervall = D�ngerIntervall;
            this.LoadAll();
        }

        #endregion

        #region Get/Set

        //*********************
        //Get/Set
        //*********************

        public void AddTemperatur(Int16 temperatur) {
            float temp = this.CalcTemperatur(temperatur);
            this.mf.ccTemperatur.AddXY(this.NextXTemperatur(), temp);
            this.TemperaturListe.Add(temp); 
        }
        public float GetTemperatur(int nr) { return this.TemperaturListe[nr]; }

        public void AddLichtst�rke(Int16 lichtst�rke) {
            float licht = this.CalcLichtst�rke(lichtst�rke);
            this.mf.ccLichtstrom.AddXY(this.NextXLichtst�rke(), licht);
            this.mf.ccLichtstrom.Invoke(new MethodInvoker(this.mf.ccLichtstrom.Refresh));
            this.LichtListe.Add(licht);
            if(this.LichtListe.Count % 30 == 0) {
                this.mf.ccLichtstrom.Invoke(new MethodInvoker(this.mf.ccLichtstrom.startNewSeries));
                this.LichtXPosition = 0;
            }
        }
        public float GetLichtst�rke(int nr) { return this.LichtListe[nr]; }

        public void AddFeuchtigkeit(Int16 feuchtigkeit) {
            float feucht = this.CalcFeuchtigkeit(feuchtigkeit);
            this.mf.ccFeuchtigkeit.AddXY(this.NextXFeuchtigkeit(), feucht);
            this.FeuchtigkeitListe.Add(feucht); 
        }
        public float GetFeuchtigkeit(int nr) { return this.FeuchtigkeitListe[nr]; }

        public void AddD�nger(Int16 d�nger) {
            float d�ng = this.CalcD�nger(d�nger);
            this.mf.ccD�nger.AddXY(this.NextXD�nger(), d�ng);
            this.D�ngerListe.Add(d�ng); 
        }
        public float GetD�nger(int nr) { return this.D�ngerListe[nr]; }

        public string GetTemperaturList() {
            string re = "";
            for (int i = 0; i < this.TemperaturListe.Count; i++) {
                re += this.TemperaturListe[i].ToString() + '\n';
            }
            return re;
        }
        public string GetFeuchtigkeitList()
        {
            string re = "";
            for (int i = 0; i < this.FeuchtigkeitListe.Count; i++) {
                re += this.FeuchtigkeitListe[i].ToString() + '\n';
            }
            return re;
        }
        public string GetLichtList()
        {
            string re = "";
            for (int i = 0; i < this.LichtListe.Count; i++) {
                re += ((int)this.LichtListe[i]).ToString() + '\n';
            }
            return re;
        }
        public string GetD�ngerList()
        {
            string re = "";
            for (int i = 0; i < this.D�ngerListe.Count; i++) {
                re += this.D�ngerListe[i].ToString() + '\n';
            }
            return re;
        }

        public double GetDurschnittsTemperatur() {
            try {
                double re = 0;
                for (int i = 0; i < this.TemperaturListe.Count - 1; i++) {
                    re += this.TemperaturListe[i];
                }
                return re / this.TemperaturListe.Count;
            }
            catch { return 0; }
        }
        public double GetDurschnittsFeuchtigkeit() {
            try{
                double re = 0;
                for (int i = 0; i < this.FeuchtigkeitListe.Count - 1; i++) {
                    re += this.FeuchtigkeitListe[i];
                }
                return re / this.FeuchtigkeitListe.Count;
            }
            catch { return 0; }
        }
        public double GetDurschnittsLicht() {
            try {
                double re = 0;
                for (int i = 0; i < this.LichtListe.Count - 1; i++) {
                    re += this.LichtListe[i];
                }
                return re / this.LichtListe.Count;
            }
            catch { return 0; }
        }
        public double GetDurschnittsD�nger() {
            try {
                double re = 0;
                for (int i = 0; i < this.D�ngerListe.Count - 1; i++) {
                    re += this.D�ngerListe[i];
                }
                return re / this.D�ngerListe.Count;
            }
            catch { return 0; }
        }

        #endregion

        #region Methoden

        //*********************
        //Methoden
        //*********************

        private float CalcTemperatur(Int16 temperatur) {
            return (Convert.ToSingle(temperatur) / 68.3f) - 83.2f ;
        }

        private float CalcLichtst�rke(Int16 lichtst�rke) {
            float value = (Convert.ToSingle(lichtst�rke)/50) - 220;

            return value < 0 ? 0 : value;
        }
        private float CalcFeuchtigkeit(Int16 feuchtigkeit) {
            return Convert.ToSingle(feuchtigkeit) / 163;
        }
        private float CalcD�nger(Int16 d�nger) {
            return Convert.ToSingle(d�nger);
        }

        private float NextXTemperatur() {
            return this.TemperaturXPosition += this.TemperaturIntervall;
        }
        private float NextXLichtst�rke() {
            return this.LichtXPosition += this.LichtIntervall;
        }
        private float NextXFeuchtigkeit() {
            return this.FeuchtigkeitXPosition += this.FeuchtigkeitIntervall;
        }
        private float NextXD�nger() {
            return this.D�ngerXPosition += this.D�ngerIntervall;
        }

        public void SaveAll() {
            StreamWriter sw;
            try {
                sw = new StreamWriter(Application.StartupPath + "\\Messwerte\\Temperatur.txt");
                sw.Write(this.GetTemperaturList());
                sw.Close();
            }
            catch { }
            try {
                sw = new StreamWriter(Application.StartupPath + "\\Messwerte\\Feuchtigkeit.txt");
                sw.Write(this.GetFeuchtigkeitList());
                sw.Close();
            }
            catch { }
            try {
                sw = new StreamWriter(Application.StartupPath + "\\Messwerte\\D�nger.txt");
                sw.Write(this.GetD�ngerList());
                sw.Close();
            }
            catch { }
            try {
                sw = new StreamWriter(Application.StartupPath + "\\Messwerte\\Lichtstrom.txt");
                sw.Write(this.GetLichtList());
                sw.Close();
            }
            catch { }
        }

        private void LoadAll() {
            string zeile;
            float z�hler = 0;
            StreamReader sr;
            try {
                sr = new StreamReader(Application.StartupPath + "\\Messwerte\\Temperatur.txt");
                while ((zeile = sr.ReadLine()) != null) {
                    this.mf.ccTemperatur.AddXY(z�hler++ * this.TemperaturIntervall, Convert.ToSingle(zeile));
                }
                this.mf.ccTemperatur.startNewSeries();
                sr.Close();
            }
            catch { }
            try {
                z�hler = 0;
                sr = new StreamReader(Application.StartupPath + "\\Messwerte\\Feuchtigkeit.txt");
                while ((zeile = sr.ReadLine()) != null) {
                    this.mf.ccFeuchtigkeit.AddXY(z�hler++ * this.FeuchtigkeitIntervall, Convert.ToSingle(zeile));
                }
                this.mf.ccFeuchtigkeit.startNewSeries();
                sr.Close();
            }
            catch { }
            try {
                z�hler = 0;
                sr = new StreamReader(Application.StartupPath + "\\Messwerte\\D�nger.txt");
                while ((zeile = sr.ReadLine()) != null) {
                    this.mf.ccD�nger.AddXY(z�hler++ * this.D�ngerIntervall, Convert.ToSingle(zeile));
                }
                this.mf.ccD�nger.startNewSeries();
                sr.Close();
            }
            catch { }
            try {
                z�hler = 0;
                sr = new StreamReader(Application.StartupPath + "\\Messwerte\\Lichtstrom.txt");
                while ((zeile = sr.ReadLine()) != null) {
                    this.mf.ccLichtstrom.AddXY(z�hler++ * this.LichtIntervall, Convert.ToSingle(zeile));
                }
                this.mf.ccLichtstrom.startNewSeries();
                sr.Close();
            }
            catch { }
        }

        #endregion
    }
}
