using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace IAC.Controls {
    /// <summary>
    ///Dieses UserControl ist ein einfaches Diagramm
    /// </summary>
    public partial class ChartControl : UserControl {
        #region Point cache
        /// <summary>
        /// Aktuelle liste
        /// </summary>
        private List<PointF> series = new List<PointF>();

        /// <summary>
        /// Alte Werte werden hier gespeichert
        /// </summary>
        private List<PointF[]> oldSeries = new List<PointF[]>();
        #endregion

        #region Configuration

        /// <summary>
        /// Pen für die Rahmen
        /// </summary>
        private Pen borderPen = new Pen(Color.Black, 6);

        /// <summary>
        /// Pen zum zeichnen der aktuellen Punktserie
        /// </summary>
        private Pen seriesPen = new Pen(Color.Blue, 3);

        /// <summary>
        /// Pen Objekt zum zeichnen der alten Punktserien
        /// </summary>
        private Pen oldSeriesPen = new Pen(Color.Gray, 3);

        /// <summary>
        /// Farben die zum Zeichnen der alten Werte benutzt werden sollen
        /// </summary>
        private Color[] oldSeriesColors = { Color.Gray, Color.Green, Color.Khaki, Color.LawnGreen, Color.Moccasin, Color.Salmon };

        /// <summary>
        /// Pen zum zeichen der Hilfslinien
        /// </summary>
        private Pen linePen = new Pen(Color.Green, 1);

        /// <summary>
        /// Brush für die Schrift
        /// </summary>
        private Brush blackBrush = Brushes.Black;
        /// <summary>
        /// Die Schrift
        /// </summary>
        private Font font;

        /// <summary>
        /// Skalierung der X-Achse
        /// </summary>
        private float scaleX = 20F;

        /// <summary>
        /// Skalierung der Y-Achse,
        /// muss negativ sein da sonst Elemente falsch platziert werden
        /// </summary>
        private float scaleY = -2F;

        /// <summary>
        /// Initialer Wert der Y Skalierung (vom Designer gesetzt)
        /// </summary>
        float initalYScale = -1;

        /// <summary>
        /// Initialer Wert der X Skalierung (vom Designer gesetzt)
        /// </summary>
        float initalXScale = 1;

        /// <summary>
        /// Speichert die alte X-Skalierung,
        /// wird benötigt für <see cref="updateScale"/>
        /// </summary>
        private float oldXScale = 1;

        /// <summary>
        /// Speichert die alte Y-Skalierung,
        /// wird benötigt für <see cref="updateScale"/>
        /// </summary>
        private float oldYScale = -1;

        /// <summary>
        /// Abstand des Graphics-Object Nullpunkts zum normalen(links oben). Wichtig beim verschieben
        /// </summary>
        private int zeroX;

        /// <summary>
        /// Abstand des Graphics-Object Nullpunkts zum normalen(links oben). Wichtig beim verschieben
        /// </summary>
        private int zeroY;

        /// <summary>
        /// Die einheit auf der X Achse
        /// </summary>
        private String suffixX = "s";

        /// <summary>
        /// Die einheit auf der Y Achse
        /// </summary>
        private String suffixY = "C";

        /// <summary>
        /// Mindesabstand der Annotationen auf der X-Achse
        /// </summary>
        private float minDistX = 25;

        /// <summary>
        /// Mindesabstand der Annotationen auf der Y-Achse
        /// </summary>
        private float minDistY = 20;

        /// <summary>
        /// Ein Skalierungswert für die X-Koordinaten aller Punkte.
        /// Er wird mit jedem Wert multipliziert
        /// </summary>
        public float ScaleX {
            get {
                return scaleX;
            }

            set {
                oldXScale = scaleX;
                scaleX = value;
                //Initial eingestellte Scale Wert für das Diagramm, wichtig beim vergrößern und verkleinern
                //Stellet die 100% Skalierung dar
                //siehe scaleBar_Scroll
                initalXScale = scaleX;
            }
        }

        /// <summary>
        /// Ein Skalierungswert für die Y-Koordinaten aller Punkte.
        /// Er wird mit jedem Wert multipliziert
        /// </summary>
        public float ScaleY {
            get {
                return -scaleY;
            }

            set {
                oldYScale = scaleY;
                //Die Y koordinate muss immer negiert werden, da die Außbreitungsrichtung der Y-Achse so ungünstig liegt (nach unten)
                //Das koordinatensystem soll aber unten links beginnen und dich nach oben ausbreiten
                scaleY = -value;

                //Initial eingestellte Scale Wert für das Diagramm, wichtig beim vergrößern und verkleinern
                //Stellet die 100% Skalierung dar
                //siehe scaleBar_Scroll
                initalYScale = scaleY;
            }
        }

        /// <summary>
        /// Bezeichner für die Einheit auf der X-Achse.
        /// Wird der Beschriftung einfach angehängt
        /// </summary>
        public String SuffixX {
            get {
                return suffixX;
            }

            set {
                suffixX = value;
            }
        }

        /// <summary>
        /// Bezeichner für die Einheit auf der Y-Achse
        /// Wird der Beschriftung einfach angehängt
        /// </summary>
        public String SuffixY {
            get {
                return suffixY;
            }

            set {
                suffixY = value;
            }
        }

        /// <summary>
        /// Minimaler Abstand der Schrift und der Hilfslinien auf der X-Achse in Pixeln
        /// </summary>
        public float MinDistX {
            get {
                return minDistX;
            }

            set {
                minDistX = value;
            }
        }

        /// <summary>
        /// Minimaler Abstand der Schrift und der Hilfslinien auf der Y-Achse in Pixeln
        /// </summary>
        public float MinDistY {
            get {
                return minDistY;
            }

            set {
                minDistY = value;
            }
        }

        /// <summary>
        /// Sämtliche Standarteinstellungen müssen für das gewünschte Verhalten definiert werden
        /// </summary>
        public ChartControl() {
            InitializeComponent();

            //Statische Einstellungen
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.SupportsTransparentBackColor |
              ControlStyles.ResizeRedraw, true);

            //Offset der Achsen vom Koordinatensystem 
            //start = new PointF(42F, -this.Height/2);

            //Initiale verschiebung des Koordinatensystems
            zeroX = 42;
            zeroY = this.Height / 2;

            //Schrift festlegen
            font = new Font(this.Font, FontStyle.Bold);

            oldSeriesPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            oldSeriesPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            seriesPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
        }
        #endregion

        #region Add Points
        /// <summary>
        /// Fügt einen neuen Punkt der Serie hinzu
        /// Die Punkte werden intern hochskaliert
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddXY(float x, float y) {
            PointF cor = new PointF(scaleX * x, scaleY * y);
            series.Add(cor);
            updateXCache();
            updateYCache();
        }

        /// <summary>
        /// Fügt eine komplette Serie hinzu.
        /// Gut zum importieren von Daten und zum
        /// darstellen alter Werte
        /// </summary>
        /// <param name="values">Liste der Punkte die hinzugefügt werden</param>
        public void AddOldSeries(List<PointF> values) {
            if (values.Count > 0) {
                PointF[] points = values.ToArray();
                for (int i = 0; i < points.Length; i++)
                    points[i] = new PointF(points[i].X * scaleX, points[i].Y * scaleY);

                oldSeries.Add(points);
            }
        }

        /// <summary>
        /// Sorgt dafür das eine neü Serie von Punkten begonnen wird
        /// die alte wird ebenfalls dargestellt
        /// </summary>
        public void startNewSeries() {
            if (series.Count > 1)
                oldSeries.Add(series.ToArray());
            series = new List<PointF>();
        }
        #endregion

        #region Paint Methoden
        /// <summary>
        /// Paint Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_Paint(object sender, PaintEventArgs e) {
            paintOn(e.Graphics);
        }

        /// <summary>
        /// Zeichnet ein Diagramm auf das Graphics Objekt
        /// </summary>
        /// <param name="screen">Das Graphics Object auf das gezeichnet werden soll</param>
        /// <param name="translateScreen">
        /// Soll der Screen verschoben dargestellt werden,
        /// sodass der Beuntzer ihn per Drag & Drop verschieben kann
        /// oder soll der Koordinatenursprung beim default Wert sein</param>
        public void paintOn(Graphics screen) {
            //Leeren des Hintergrubdes
            screen.Clear(this.BackColor);
            screen.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

            screen.PageUnit = GraphicsUnit.Pixel;

            /*
             * Setzen des Ursprungs auf links unten
             * Zerox und zeroY wrden weiter unten in in den Event Handlern gesetzt,
             * sodass Drag&Drop funktioniert
             */
            screen.TranslateTransform(zeroX, zeroY);

            //Alles zeichnen
            paintChart(screen.VisibleClipBounds.Width - zeroX, screen.VisibleClipBounds.Height, screen);
        }

        /// <summary>
        /// Zeichnet das gesamte Diagamm auf basis der verschidenen Punktelisten
        /// </summary>
        /// <param name="width">Breite</param>
        /// <param name="heigth">Höhe</param>
        private void paintChart(float width, float heigth, Graphics screen) {
            /*HOTFIX*/
            heigth = 5 * heigth;
            //Achsen zeichnen - nach oben und rechts
            PointF topEdge = new PointF(0, -heigth);
            PointF zeroEdge = new PointF(0, 0);
            PointF rightEdge = new PointF(width, 0);

            /*HOTFIX*/
            screen.DrawLine(borderPen, new PointF(-5000, 0), rightEdge);

            screen.DrawLines(borderPen, new PointF[] { topEdge, zeroEdge, rightEdge });

            //Achsen zeichnen - nach unten und nach links
            PointF leftEdge = new PointF(-width, 0);
            PointF bottomEdge = new PointF(0, heigth);
            screen.DrawLines(borderPen, new PointF[] { leftEdge, zeroEdge, bottomEdge });

            //Die alten Punktserien einfügen und Färben
            if (oldSeries.Count > 0)
                for (int i = 0; i < oldSeries.Count; i++) {//Es wird eine einfärbung vorgenommen auf basis der Farbliste.
                    oldSeriesPen.Color = oldSeriesColors[i % oldSeriesColors.Length];
                    screen.DrawLines(oldSeriesPen, oldSeries[i]);
                }

            if (series.Count > 1)//Mindestens 2 Punkte sollen vorhanden sein
            {
                //Punkte verbinden mit Standart farbe
                screen.DrawLines(seriesPen, series.ToArray());

                //Beschriftung auf den Achsen und Hilfslinien
                //Aber nur da wo es sich nicht überlagert
                foreach (PointF point in checkedXCache)//Alle Punkte die im X-Achsen Cache sind
                {
                    //X-Achse - Beschriftung
                    //Es wird gezeichnet was als input für den Punkt einegeben wurde, indem zurückgerechnet wird und dann gerundet
                    screen.DrawString(Math.Round(point.X / scaleX).ToString() + suffixX,
                        font,
                        blackBrush,
                        new PointF(point.X, 8F));//8 Pixel nach unten wegen der Schriftgrösse
                    //Von unten bis zum Punkt zeichnen
                    screen.DrawLine(linePen, new PointF(point.X, 0), new PointF(point.X, point.Y));
                }

                foreach (PointF point in checkedYCache)//Alle Punkte die im Y-Achsen Cache sind
                {
                    //Y-Achse - Beschriftung
                    //Es wird gezeichnet was als input für den Punkt eingegeben wurde,
                    //indem zurückgerechnet wird und dann gerundet
                    screen.DrawString(Math.Round(point.Y / scaleY).ToString() + suffixY,
                        font,
                        blackBrush,
                        new PointF(-zeroX + 5, point.Y));
                    //Indem man die X-Koordinate auf -zeroX setzt, bleiben sie am linken Rand kleben
                    //Das verbessert die übersicht

                    //Von links bis zum Punkt zeichnen
                    screen.DrawLine(linePen, new PointF(0, point.Y), new PointF(point.X, point.Y));
                }
            }
        }
        #endregion

        #region pointManipulation
        /// <summary>
        /// Skaliert alle Punkte die das Diagramm enthält neu.
        /// Intern: Beachten das die oldXScale Werte immer gesetzt sind
        /// ebense wie
        /// </summary>
        /// <see cref="ScaleX"/>
        /// <see cref="ScaleY"/>
        private void updateScale() {
            /*
             * Da ich keine unskalierten Werte speichere müssen bevor die Werte neu skaliert werden können
             * alle Werte auf ihren ursprungszustand zurückgerechnet werden
             * Dazu werden auch immer die alten Werte gebraucht
             */
            if (series.Count > 1) {
                List<PointF> tmp = new List<PointF>();
                //Jeden Punkt aufwendig Umrechnen auf die neü Skalierung,
                //Der rechenaufwand ist aber selbst auf den Rechnern in der Schule tragbar
                foreach (PointF point in series) {
                    float x = (point.X) / oldXScale;
                    float y = (point.Y) / oldYScale;
                    tmp.Add(new PointF(scaleX * x, scaleY * y));
                }
                //Alte skalierung mit der neün tauschen
                series = tmp;
            }

            //Alle alten Punkte neu skalieren
            if (oldSeries.Count > 0)
                foreach (PointF[] points in oldSeries) {
                    for (int i = 0; i < points.Length; i++) {
                        float x = points[i].X / oldXScale;
                        float y = points[i].Y / oldYScale;
                        points[i] = new PointF(scaleX * x, scaleY * y);
                    }
                }

            //Hilfslinien neu Berechnen
            updateXCache();
            updateYCache();
        }

        /// <summary>
        /// Speichert álle Pubkte die auf der X-Achse dargestellt werden sollen.
        /// </summary>
        private List<PointF> checkedXCache = new List<PointF>();

        /// <summary>
        /// Sortiert zu eng beieinander liegende Punkte aus,
        /// sodass diese bei Beschriftung und Hilfslinien ausgelassen werden
        /// Auch als PAP Dokumentiert
        /// </summary>
        private void updateXCache() {
            //Absolut Magischer Algorithmus ;)
            if (series.Count > 0) {
                checkedXCache = new List<PointF>(series);//Kopie aller Akzüllen Punkte anlegen
                bool finished = false;//Laufzeitvariable die Bestimmt wann der Algorithmus fertig ist
                //Variable für den Aktuellen Punkt
                PointF point1 = checkedXCache[checkedXCache.Count - 1];//Beim start immmer der letzte aus der Liste

                do {
                    //Speicherliste für die Elemente die Entfernt werden sollen
                    List<PointF> removeItems = new List<PointF>();
                    foreach (PointF point2 in checkedXCache)//Schleife durch alle Punkte
                    {
                        //Vergleicht jeden Punkt mit dem Startpunkt und schaut ob der Abstand groß genug ist
                        //Die Punkte dürfen nicht gleich sein
                        if (point1 != point2 && !(Math.Abs(point1.X - point2.X) >= minDistX))
                            removeItems.Add(point2);
                        /* 
                         * Sollte der Abstand nicht groß genug sein, wird der Punkt zu entfernen Liste hinzugefügt
                         * Die removeItems-Liste wird gebraucht, da man die checkedXCache-Liste,
                         * während der Schleife, nicht verändern darf
                         */
                    }

                    //Die ELemente entfernen
                    foreach (PointF rmItem in removeItems)
                        checkedXCache.Remove(rmItem);

                    //Index neu Berechnen, immer das Element vor dem jetzigen 
                    int newIndex = checkedXCache.IndexOf(point1) - 1;
                    if (newIndex >= 0)//Schaün ob die Liste noch nicht zu ende ist
                        point1 = checkedXCache[newIndex];//Startpunkt neu definieren
                    else
                        finished = true;//Fertig

                } while (!finished);
            }
        }

        private List<PointF> checkedYCache = new List<PointF>();

        /// <summary>
        /// Sortiert zu eng beieinander liegende Punkte aus,
        /// sodass diese bei Beschriftung und Hilfslinien ausgelassen werden.
        /// Und sortiert Punkte aus, deren Beschriftung in der Achse liegt
        /// </summary>
        /// <param name="basis"></param>
        private void updateYCache() {
            //Absolut Magischer Algorithmus ;)
            if (series.Count > 0) {
                checkedYCache = new List<PointF>(series);//Kopie aller Akzüllen Punkte anlegen
                bool finished = false;//Laufzeitvariable die Bestimmt wann der Algorithmus fertig ist
                //Variable für den Aktuellen Punkt
                PointF point1 = checkedYCache[checkedYCache.Count - 1];//Beim start immmer der letzte aus der Liste
                do {
                    //Speicherliste für die Elemente die Entfernt werden sollen
                    List<PointF> removeItems = new List<PointF>();
                    foreach (PointF point2 in checkedYCache)//Schleife durch alle Punkte
                    {
                        /*
                         * Vergleicht jeden Punkt mit dem Startpunkt und schaut ob der Abstand groß genug ist
                         * Die Punkte dürfen nicht gleich sein
                         * Der Punkt (die Beschriftung) soll nicht in die Y-Achse Rutschen
                         */
                        if (point1 != point2 && !(Math.Abs(point1.Y - point2.Y) >= minDistY))
                            removeItems.Add(point2);
                        /* 
                         * Sollte der Abstand nicht groß genug sein, wird der Punkt zu entfernen Liste hinzugefügt
                         * Die removeItems-Liste wird gebraucht, da man die checkedYCache-Liste,
                         * während der Schleife, nicht verändern darf
                         */
                    }

                    //Die ELemente entfernen
                    foreach (PointF rmItem in removeItems)
                        checkedYCache.Remove(rmItem);

                    //Index neu Berechnen, immer das Element vor dem jetzigen 
                    int newIndex = checkedYCache.IndexOf(point1) - 1;
                    if (newIndex >= 0)//Schaün ob die Liste noch nicht zu ende ist
                        point1 = checkedYCache[newIndex];//Startpunkt neu definieren
                    else
                        finished = true;//Fertig

                } while (!finished);
            }
        }

        private void moveZeroRelative(int x, int y) {
            zeroX += x;
            zeroY += y;
            this.Refresh();
        }
        #endregion

        #region Mouse Handlers
        private bool dragAction = false;
        private int mouseX = 0;
        private int mouseY = 0;

        /// <summary>
        /// Startet die Bewegen Operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_MouseDown(object sender, MouseEventArgs e) {
            dragAction = true;
        }

        /// <summary>
        /// Reagiert auf die Bewegungen und ändert das Diagramm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_MouseMove(object sender, MouseEventArgs e) {
            if (dragAction) {
                zeroX += e.X - mouseX;
                zeroY += e.Y - mouseY;
                this.Refresh();
            }
            mouseX = e.X;
            mouseY = e.Y;
        }

        /// <summary>
        /// Beendet das Verschieben, indem man den Mauszeiger losläst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_MouseUp(object sender, MouseEventArgs e) {
            dragAction = false;
        }

        /// <summary>
        /// Zeigt einen Toolstrp an, der den Nutzer,
        /// über die Werte an der jeweiligen Stelle informiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartControl_MouseHover(object sender, EventArgs e) {
            //Berechnet die Werte die angezeigt werden sollen
            float x = (mouseX - zeroX) / scaleX;
            float y = (mouseY - zeroY) / scaleY;
            //Zeigt sie am Mauszeiger an
            valueToolTip.Show(String.Format("{0}{1}; {2}{3}", Math.Round(x, 1), suffixX, Math.Round(y, 2), suffixY),
                this, new Point(mouseX, mouseY), 1000);
        }
        #endregion

        #region Scale Handlers
        /// <summary>
        /// Event Handler der auf das Scrollen der ScrollBar reagiert und das
        /// Diagramm neu skaliert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scaleBar_Scroll(object sender, ScrollEventArgs e) {
            //Ich nehme den Referenzwert vom anfang als Maximalwert
            if (scaleBar.Value != 0) {// Einfach mit simpler Prozentrechnung skaliert
                float x = ((Convert.ToSingle(scaleBar.Value) / 100F) * initalXScale);
                float y = ((Convert.ToSingle(scaleBar.Value) / 100F) * initalYScale);
                //Verhindern das der Viewport aus dem Bild rutscht
                //chart.MoveCenterRelative((int)(chart.ScaleX - x), (int)(chart.ScaleY - y));

                oldXScale = scaleX;
                oldYScale = scaleY;

                //Skalierung updaten
                scaleX = x;
                scaleY = y;

                float xValue = 0;
                if (series.Count > 0)
                    xValue = series[series.Count - 1].X;

                this.updateScale();//Skalierung neu berechnen, ansonsten würde nur neüs angepasst

                if (series.Count > 0)
                    moveZeroRelative((int)(xValue - series[series.Count - 1].X), 0);

                //Für den Benutzer die Vergrößerung sichtbar machen
                scaleBarLabel.Text = scaleBar.Value + "%";

                this.Refresh();//ChartControl neu zeichnen
            }
        }

        /// <summary>
        /// Sorgt dafür das beím Verändern des Fensters
        /// die Achse mit angepasst wird und in der Mitte bleibt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartControl_Resize(object sender, EventArgs e) {
            zeroY = this.Height / 2;
            updateScale();
        }
        #endregion

    }
}
