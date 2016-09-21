// Arrays for nodes and icons
var nodes = new Array();;
var openNodes = new Array();
var icons = new Array(6);

var target = "";

// Loads all icons that are used in the tree
function preloadIcons() {
    icons[0] = new Image();
    icons[0].src = "img/plus.gif";
    icons[1] = new Image();
    icons[1].src = "img/plusbottom.gif";
    icons[2] = new Image();
    icons[2].src = "img/minus.gif";
    icons[3] = new Image();
    icons[3].src = "img/minusbottom.gif";
    icons[4] = new Image();
    icons[4].src = "img/folder.gif";
    icons[5] = new Image();
    icons[5].src = "img/folderopen.gif";
}


// Create the tree
function createTree(arrName, targ, startNode, openNode) {

    nodes = new Array();;
    openNodes = new Array();
    icons = new Array(6);

    target = "";

    nodes = arrName;

    if (nodes.length > 0) {
        preloadIcons();
        if (startNode == null) startNode = 0;
        if (openNode != 0 || openNode != null) setOpenNodes(openNode);

        if (startNode != 0) {
            var nodeValues = nodes[getArrayId(startNode)].split("|");
            target += '<span onclick="' + nodeValues[3] + '"><img src="img/folderopen.gif" align="absbottom" />' + nodeValues[2] + '</span><br />';
        } else
            target += '<img src="img/base.gif" align="absbottom" alt="" />Website<br />';

        var recursedNodes = new Array();
        addNode(startNode, recursedNodes, targ);
        targ.innerHTML = target;

        target = null;
    }
}
// Returns the position of a node in the array
function getArrayId(node) {
    for (i = 0; i < nodes.length; i++) {
        var nodeValues = nodes[i].split("|");
        if (nodeValues[0] == node) return i;
    }
}
// Puts in array nodes that will be open
function setOpenNodes(openNode) {
    for (i = 0; i < nodes.length; i++) {

        try {
            var nodeValues = nodes[i].split("|");
            if (nodeValues[0] == openNode) {
                openNodes.push(nodeValues[0]);
                setOpenNodes(nodeValues[1]);
            }
        } catch (e) {
            console.log(nodes[i]);
        }

    }
}
// Checks if a node is open
function isNodeOpen(node) {
    for (i = 0; i < openNodes.length; i++)
        if (openNodes[i] == node) return true;
    return false;
}
// Checks if a node has any children
function hasChildNode(parentNode) {
    for (i = 0; i < nodes.length; i++) {
        var nodeValues = nodes[i].split("|");
        if (nodeValues[1] == parentNode) return true;
    }
    return false;
}
// Checks if a node is the last sibling
function lastSibling(node, parentNode) {
    var lastChild = 0;
    for (i = 0; i < nodes.length; i++) {
        var nodeValues = nodes[i].split("|");
        if (nodeValues[1] == parentNode)
            lastChild = nodeValues[0];
    }
    if (lastChild == node) return true;
    return false;
}
// Adds a new node to the tree
function addNode(parentNode, recursedNodes, targ) {

    for (var i = 0; i < nodes.length; i++) {

        var nodeValues = nodes[i].split("|");
        if (nodeValues[1] == parentNode) {

            var ls = lastSibling(nodeValues[0], nodeValues[1]);
            var hcn = hasChildNode(nodeValues[0]);
            var ino = isNodeOpen(nodeValues[0]);

            // Write out line & empty icons
            for (g = 0; g < recursedNodes.length; g++) {
                if (recursedNodes[g] == 1)
                    target += '<img src="img/line.gif" align="absbottom" alt="" />';
                else
                    target += '<img src="img/empty.gif" align="absbottom" alt="" />';
            }

            // put in array line & empty icons
            if (ls) recursedNodes.push(0);
            else recursedNodes.push(1);

            // Write out join icons
            if (hcn) {
                if (ls) {
                    target += '<a href="javascript: oc(' + nodeValues[0] + ', 1);"><img id="join' + nodeValues[0] + '" src="img/';
                    if (ino)
                        target += "minus";
                    else
                        target += "plus";

                    target += 'bottom.gif" align="absbottom" alt="Open/Close node" /></a>';
                } else {
                    target += '<a href="javascript: oc(' + nodeValues[0] + ', 0);"><img id="join' + nodeValues[0] + '" src="img/';
                    if (ino)
                        target += "minus";
                    else
                        target += "plus";

                    target += '.gif" align="absbottom" alt="Open/Close node" /></a>';
                }
            } else {
                if (ls)
                    target += '<img src="img/joinbottom.gif" align="absbottom" alt="" />';
                else
                    target += '<img src="img/join.gif" align="absbottom" alt="" />';
            }

            // Start link
            target += '<span onclick="' + nodeValues[3] + '">';

            // Write out folder & page icons
            if (hcn) {
                target += '<img id="icon' + nodeValues[0] + '" src="img/folder';
                if (ino)
                    target += "open";
                target += '.gif" align="absbottom" alt="Folder" />';
            } else
                target += '<img id="icon' + nodeValues[0] + '" src="img/page.gif" align="absbottom" alt="Page" />';

            // Write out node name
            target += nodeValues[2];

            // End link
            target += "</span><br />";

            // If node has children write out divs and go deeper
            if (hcn) {
                target += "<div id=\"div" + nodeValues[0] + "\"";
                if (!ino) target += " style=\"display: none;\"";
                target += ">";
                addNode(nodeValues[0], recursedNodes, target);
                target += "</div>";
            }

            // remove last line or empty icon 
            recursedNodes.pop();
        }
    }
}
// Opens or closes a node
function oc(node, bottom) {
    var theDiv = document.getElementById("div" + node);
    var theJoin = document.getElementById("join" + node);
    var theIcon = document.getElementById("icon" + node);

    if (theDiv.style.display == 'none') {
        if (bottom == 1) theJoin.src = icons[3].src;
        else theJoin.src = icons[2].src;
        theIcon.src = icons[5].src;
        theDiv.style.display = '';
    } else {
        if (bottom == 1) theJoin.src = icons[1].src;
        else theJoin.src = icons[0].src;
        theIcon.src = icons[4].src;
        theDiv.style.display = 'none';
    }
}
// Push and pop not implemented in IE
if (!Array.prototype.push) {
    function array_push() {
        for (var i = 0; i < arguments.length; i++)
            this[this.length] = arguments[i];
        return this.length;
    }
    Array.prototype.push = array_push;
}
if (!Array.prototype.pop) {
    function array_pop() {
        lastElement = this[this.length - 1];
        this.length = Math.max(this.length - 1, 0);
        return lastElement;
    }
    Array.prototype.pop = array_pop;
}
