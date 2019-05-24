using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BoundaryTask.Actionss
{
    public static class UiActionExtensions
    {
        public static ToolStripItem[] ToMenuItems(this IUiAction[] actions)
        {
            var items = actions.GroupBy(a => a.Category)
                .Select(g => CreateToplevelMenuItem(g.Key, g.ToList()))
                .Cast<ToolStripItem>()
                .ToArray();
            return items;
        }

        private static ToolStripMenuItem CreateToplevelMenuItem(string name, IList<IUiAction> items)
        {
            var menuItems = items.Select(a => a.ToMenuItem()).ToArray();
            return new ToolStripMenuItem(name, null, menuItems);
        }

        public static ToolStripItem ToMenuItem(this IUiAction action)
        {
            return
                new ToolStripMenuItem(action.Name, null, (sender, args) => action.Perform())
                {
                    Tag = action,
                    BackColor = Color.MediumPurple
                };
        }
    }
}