using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Examples.WinForms.Controls
{

    /// <summary>
    /// グループ化されたリストを持つドロップダウンリスト コントロールを表します。
    /// </summary>
    [DefaultBindingProperty("Text")
        , DefaultEvent("SelectedIndexChanged")
        , DefaultProperty("Items")]
    public partial class GroupingDropDownList : ComboBox
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public GroupingDropDownList() : base()
        {
            InitializeComponent();

            this.SuspendLayout();
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.DrawMode = DrawMode.OwnerDrawVariable;
            this.MaxDropDownItems = 30;
            this.ResumeLayout();
        }


        #region Prooperty(New) --- DropDownStyle
        /// <summary>
        /// コンボ ボックスのスタイルを指定する値を取得します。
        /// </summary>
        /// <returns>
        /// 常に DropDownList を返却します。
        /// </returns>
        [ReadOnly(true)
            , Category("Appearance")
            , DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:メンバーを static に設定します", Justification = "<保留中>")]
        public new ComboBoxStyle DropDownStyle => ComboBoxStyle.DropDownList;
        #endregion

        #region Prooperty(New) --- DrawMode
        /// <summary>
        /// リストの要素を描画を処理するのは、コードとオペレーティング システムのどちらであるかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// 常に OwnerDrawVariable を返却します。
        /// </returns>
        [ReadOnly(true)
            , Category("Behavior")
            , DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:メンバーを static に設定します", Justification = "<保留中>")]
        public new DrawMode DrawMode => DrawMode.OwnerDrawVariable;
        #endregion

        #region Prooperty(New) --- MaxDropDownItems
        /// <summary>
        /// ドロップダウン部分に表示される項目の最大数を取得または設定します。
        /// </summary>
        /// <returns>
        /// 最大数が 1 未満または 100 を超える数値に設定されています。
        /// </returns>
        [DefaultValue(30), Localizable(true)
            , Category("Behavior")]
        public new int MaxDropDownItems
        {
            get { return base.MaxDropDownItems; }
            set { base.MaxDropDownItems = value; }
        }
        #endregion


        #region Property --- GroupingValueMember
        /// <summary>
        /// ドロップダウンリストをグルーピングする値を取得または設定します。
        /// </summary>
        /// <remarks>
        /// データはこの値でソートされている必要があります。
        /// </remarks>
        [DefaultValue(null)
            , Bindable(true, BindingDirection.OneWay)
            , Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Culture=neutral", typeof(System.Drawing.Design.UITypeEditor))
            , TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Culture=neutral")
            , Category("Data")]
        public string GroupingValueMember
        {
            get { return _GroupingValueMember; }
            set
            {
                if (_GroupingValueMember != value)
                {
                    _GroupingValueMember = value;
                    //OnDataSourceChanged(EventArgs.Empty);
                }
            }
        }
        private string _GroupingValueMember;
        #endregion

        #region Property --- GroupingDisplayMember
        /// <summary>
        /// ドロップダウンリストのグループとして表示する値を取得または設定します。
        /// </summary>
        [DefaultValue(null)
            , Bindable(true, BindingDirection.OneWay)
            , Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Culture=neutral", typeof(System.Drawing.Design.UITypeEditor))
            , TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Culture=neutral")
            , Category("Data")]
        public string GroupingDisplayMember
        {
            get { return _GroupingDisplayMember; }
            set
            {
                if (_GroupingDisplayMember != value)
                {
                    _GroupingDisplayMember = value;
                    //OnDataSourceChanged(EventArgs.Empty);
                }
            }
        }
        private string _GroupingDisplayMember;
        #endregion

        #region Property --- GroupingForeColor
        /// <summary>
        /// グループの前景色を取得または設定します。
        /// </summary>
        [DefaultValue(typeof(Color), "WindowText")
           , Category("Appearance")]
        public Color GroupingForeColor
        {
            get { return _GroupingForeColor; }
            set { _GroupingForeColor = value; }
        }
        private Color _GroupingForeColor = SystemColors.WindowText;
        #endregion

        #region Property --- GroupingBackColor
        /// <summary>
        /// グループの前景色を取得または設定します。
        /// </summary>
        [DefaultValue(typeof(Color), "Control")
           , Category("Appearance")]
        public Color GroupingBackColor
        {
            get { return _GroupingBackColor; }
            set { _GroupingBackColor = value; }
        }
        private Color _GroupingBackColor = SystemColors.Control;
        #endregion

        #region Property --- ItemGroupHeight
        /// <summary>
        ///  コンボ ボックス内の項目の高さを取得または設定します。
        /// </summary>
        [Localizable(true)
            , Category("Behavior")]
        public int ItemGroupHeight
        {
            get
            {
                if (__ItemGroupHeight > 0)
                {
                    return __ItemGroupHeight;
                }
                return this.ItemHeight;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("ItemGroupHeight");
                }
                __ItemGroupHeight = value;
            }
        }
        private int __ItemGroupHeight = 0;
        #endregion


        /// <summary>
        /// <see cref="E:System.Windows.Forms.ComboBox.DrawItem" /> イベントを発生させます。
        /// </summary>
        /// <param name="e">イベント データを格納している <see cref="T:System.Windows.Forms.DrawItemEventArgs" />。</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                DataRowView current = this.Items[e.Index] as DataRowView;
                bool isCategoryTop = (e.Bounds.Height > this.ItemHeight);
                if (isCategoryTop)
                {
                    using Brush foreBrush = new SolidBrush(this.GroupingForeColor);
                    using Brush backBrush = new SolidBrush(this.GroupingBackColor);

                    var rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, this.ItemGroupHeight);
                    e.Graphics.FillRectangle(backBrush, rect);
                    e.Graphics.DrawString(current[this.GroupingDisplayMember].ToString()
                                        , e.Font
                                        , foreBrush
                                        , rect.X + 1
                                        , rect.Y + 1
                    );

                }

                int indentWidth = TextRenderer.MeasureText(" ", e.Font).Width;
                bool isIndent = ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit);
                isIndent &= (current[this.GroupingValueMember] != DBNull.Value);
                {
                    using Brush foreBrush = new SolidBrush(e.ForeColor);

                    e.Graphics.DrawString(current[this.DisplayMember].ToString()
                                        , e.Font
                                        , foreBrush
                                        , e.Bounds.X + (isIndent ? indentWidth : 0) + 1
                                        , e.Bounds.Y + (isCategoryTop ? this.ItemGroupHeight : 0) + 1
                    );

                }
            }

            e.DrawFocusRectangle();
            base.OnDrawItem(e);
            return;
        }

        /// <summary>
        /// <see cref="E:System.Windows.Forms.ComboBox.MeasureItem" /> イベントを発生させます。
        /// </summary>
        /// <param name="e">イベント データを格納している <see cref="T:System.Windows.Forms.MeasureItemEventArgs" />。</param>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (this.GroupingValueMember != null)
            {
                bool isCategoryTop = false;
                for (; ; )
                {
                    if (e.Index >= 0)
                    {
                        DataRowView data = this.Items[e.Index] as DataRowView;
                        if (data[this.GroupingValueMember] == DBNull.Value)
                        {
                            break;
                        }
                    }

                    if (e.Index == 0)
                    {
                        isCategoryTop = true;
                        break;
                    }

                    if (e.Index > 0)
                    {
                        DataRowView current = this.Items[e.Index] as DataRowView;
                        DataRowView prev = this.Items[e.Index - 1] as DataRowView;
                        if (prev[this.GroupingValueMember].ToString() != current[this.GroupingValueMember].ToString())
                        {
                            isCategoryTop = true;
                            break;
                        }
                    }
                    break;
                }

                if (isCategoryTop)
                {
                    e.ItemHeight += this.ItemGroupHeight;
                }
            }

            base.OnMeasureItem(e);
            return;
        }

    }
}
